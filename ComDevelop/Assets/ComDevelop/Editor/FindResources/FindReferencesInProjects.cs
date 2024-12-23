using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 项目引用查找工具：在项目中查找资源的引用
    /// Project Reference Finder: Find asset references in project files
    /// </summary>
    public class FindReferencesInProjects
    {
        // 用于存储搜索结果
        private class SearchResult
        {
            public string FilePath;
            public Object Asset;
            public string FileType;

            public SearchResult(string filePath, Object asset, string fileType)
            {
                FilePath = filePath;
                Asset = asset;
                FileType = fileType;
            }
        }

        private static List<SearchResult> searchResults = new List<SearchResult>();
        private static readonly string[] SEARCH_EXTENSIONS = { ".prefab", ".unity", ".mat", ".asset" };

        [MenuItem("Assets/Find References in Projects", false, 20)]
        static private void Find()
        {
            // 清空上次的搜索结果
            searchResults.Clear();

            // 确保使用文本序列化模式
            EditorSettings.serializationMode = SerializationMode.ForceText;
            
            // 获取选中资源的路径和GUID
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogWarning("[FindReferences] No asset selected.");
                return;
            }

            string guid = AssetDatabase.AssetPathToGUID(path);
            string searchingAssetName = Selection.activeObject.name;

            // 获取所有需要搜索的文件
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => SEARCH_EXTENSIONS.Contains(Path.GetExtension(s).ToLower()))
                .ToArray();

            int startIndex = 0;
            EditorApplication.update = delegate()
            {
                // 显示进度条
                string file = files[startIndex];
                bool isCancel = EditorUtility.DisplayCancelableProgressBar("Searching References",
                    string.Format("Searching file {0} ({1}/{2})", Path.GetFileName(file), startIndex + 1, files.Length),
                    (float)startIndex / files.Length);

                // 搜索当前文件
                string content = File.ReadAllText(file);
                if (content.Contains(guid))
                {
                    string fileType = Path.GetExtension(file).ToUpper().Substring(1);
                    string relativePath = GetRelativeAssetsPath(file);
                    Object asset = AssetDatabase.LoadAssetAtPath<Object>(relativePath);
                    
                    searchResults.Add(new SearchResult(relativePath, asset, fileType));
                }

                startIndex++;
                if (isCancel || startIndex >= files.Length)
                {
                    // 搜索完成或用户取消
                    EditorUtility.ClearProgressBar();
                    EditorApplication.update = null;
                    PrintSearchResults(searchingAssetName);
                }
            };
        }

        /// <summary>
        /// 打印搜索结果
        /// </summary>
        private static void PrintSearchResults(string searchingAssetName)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("==================================================");
            
            if (searchResults.Count == 0)
            {
                result.AppendLine(string.Format("No references found for '{0}'", searchingAssetName));
            }
            else
            {
                result.AppendLine(string.Format("Found {0} references for '{1}':", searchResults.Count, searchingAssetName));
            }
            
            result.AppendLine("==================================================");

            // 按文件类型分组显示结果
            var groupedResults = searchResults
                .GroupBy(r => r.FileType)
                .OrderBy(g => g.Key);

            foreach (var group in groupedResults)
            {
                result.AppendLine(string.Format("\nIn {0} Files:", group.Key));
                foreach (var item in group)
                {
                    result.AppendLine(string.Format("  └─ {0}", item.FilePath));
                    // 在Console中点击可以定位到对应资源
                    Debug.Log(string.Format("    Reference found in: {0}", item.FilePath), item.Asset);
                }
            }

            result.AppendLine("\n==================================================");
            Debug.Log(result.ToString());
        }

        [MenuItem("Assets/Find References in Projects", true)]
        static private bool ValidateFind()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            return !string.IsNullOrEmpty(path);
        }

        /// <summary>
        /// 获取相对于Assets文件夹的路径
        /// </summary>
        static private string GetRelativeAssetsPath(string fullPath)
        {
            return "Assets" + Path.GetFullPath(fullPath)
                .Replace(Path.GetFullPath(Application.dataPath), "")
                .Replace('\\', '/');
        }
    }
}