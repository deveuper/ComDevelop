using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;
using UnityEditor.SceneManagement;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 场景引用查找工具：查找预制体在所有场景中的引用位置
    /// Scene Reference Finder: Find prefab references in all scenes
    /// </summary>
    public class FindReferenceAllScene : MonoBehaviour
    {
        // 用于存储搜索结果的结构
        private class SearchResult
        {
            public string ScenePath;
            public string ObjectPath;
            public GameObject GameObject;

            public SearchResult(string scenePath, string objectPath, GameObject gameObject)
            {
                ScenePath = scenePath;
                ObjectPath = objectPath;
                GameObject = gameObject;
            }
        }

        private static List<SearchResult> searchResults = new List<SearchResult>();

        [MenuItem("Assets/Find Reference in All Scenes", false, 21)]
        private static void OnSearchForReferences()
        {
            // 清空上次的搜索结果
            searchResults.Clear();

            // 检查选择的是否为单个对象 | Check if single object is selected
            if (Selection.gameObjects == null || Selection.gameObjects.Length != 1)
            {
                Debug.LogWarning("[FindReference] Please select one prefab.");
                return;
            }

            // 保存当前场景 | Save current scene
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                string searchPath = AssetDatabase.GetAssetPath(Selection.activeGameObject);
                string currentScenePath = EditorSceneManager.GetActiveScene().path;
                int sceneCount = EditorBuildSettings.scenes.Length;

                // 遍历所有场景 | Iterate all scenes
                for (int i = 0; i < sceneCount; i++)
                {
                    EditorBuildSettingsScene scene = EditorBuildSettings.scenes[i];
                    if (!scene.enabled)
                    {
                        continue;
                    }

                    // 显示进度条 | Show progress bar
                    if (ShowProgressBar(i, sceneCount, scene.path))
                    {
                        break; // 用户取消操作 | User cancelled
                    }

                    // 打开场景 | Open scene
                    EditorSceneManager.OpenScene(scene.path);

                    // 查找场景中的所有引用 | Find all references in scene
                    SearchSceneForReferences(scene.path, searchPath);
                }

                // 恢复原始场景 | Restore original scene
                EditorSceneManager.OpenScene(currentScenePath);
                EditorUtility.ClearProgressBar();

                // 打印搜索结果
                PrintSearchResults(Selection.activeGameObject.name);
            }
        }

        /// <summary>
        /// 在当前场景中搜索引用 | Search references in current scene
        /// </summary>
        private static void SearchSceneForReferences(string scenePath, string searchPath)
        {
            GameObject[] sceneObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));
            
            for (int i = 0; i < sceneObjects.Length; i++)
            {
                GameObject go = sceneObjects[i];
                
                // 检查是否为预制体实例 | Check if prefab instance
                PrefabType prefabType = PrefabUtility.GetPrefabType(go);
                if (prefabType != PrefabType.PrefabInstance)
                {
                    continue;
                }

                // 获取预制体源 | Get prefab source
                Object parentObject = EditorUtility.GetPrefabParent(go);
                string prefabPath = AssetDatabase.GetAssetPath(parentObject);

                // 检查是否匹配 | Check if matches
                if (prefabPath == searchPath)
                {
                    // 将结果添加到列表中
                    searchResults.Add(new SearchResult(
                        scenePath,
                        GetGameObjectPath(go),
                        go
                    ));
                }
            }
        }

        /// <summary>
        /// 打印搜索结果
        /// </summary>
        private static void PrintSearchResults(string searchObjectName)
        {
            if (searchResults.Count == 0)
            {
                Debug.Log(string.Format("[FindReference] No references found for '{0}'", searchObjectName));
                return;
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine("==================================================");
            result.AppendLine(string.Format("Found {0} references for '{1}':", searchResults.Count, searchObjectName));
            result.AppendLine("==================================================");

            string currentScene = string.Empty;
            for (int i = 0; i < searchResults.Count; i++)
            {
                SearchResult sr = searchResults[i];
                
                // 如果是新场景，打印场景名
                if (currentScene != sr.ScenePath)
                {
                    currentScene = sr.ScenePath;
                    result.AppendLine(string.Format("\nIn Scene: {0}", sr.ScenePath));
                }

                // 打印对象路径
                result.AppendLine(string.Format("  └─ {0}", sr.ObjectPath));
                
                // 如果对象有特殊组件，也可以打印出来
                Component[] components = sr.GameObject.GetComponents<Component>();
                if (components.Length > 1) // 大于1是因为Transform组件总是存在
                {
                    result.AppendLine("     Components:");
                    for (int j = 0; j < components.Length; j++)
                    {
                        if (components[j] != null && !(components[j] is Transform))
                        {
                            result.AppendLine(string.Format("       ├─ {0}", components[j].GetType().Name));
                        }
                    }
                }
            }

            result.AppendLine("\n==================================================");
            Debug.Log(result.ToString());
        }

        /// <summary>
        /// 获取游戏对象的层级路径 | Get hierarchy path of game object
        /// </summary>
        private static string GetGameObjectPath(GameObject obj)
        {
            if (!obj)
            {
                return string.Empty;
            }

            StringBuilder path = new StringBuilder(obj.name);
            Transform parent = obj.transform.parent;

            while (parent)
            {
                path.Insert(0, "/");
                path.Insert(0, parent.name);
                parent = parent.parent;
            }

            return path.ToString();
        }

        /// <summary>
        /// 显示进度条 | Show progress bar
        /// </summary>
        private static bool ShowProgressBar(int current, int total, string scenePath)
        {
            float progress = (float)current / total;
            string info = string.Format("Searching scene {0} ({1}/{2})", 
                scenePath, current + 1, total);
                
            return EditorUtility.DisplayCancelableProgressBar(
                "Finding References", 
                info, 
                progress);
        }

        [MenuItem("Assets/Find Reference in All Scenes", true)]
        private static bool ValidateSearchForReferences()
        {
            // 验证是否选择了有效对象 | Validate if valid object is selected
            return Selection.activeObject != null && 
                   !string.IsNullOrEmpty(AssetDatabase.GetAssetPath(Selection.activeObject));
        }
    }
}