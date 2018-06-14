
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class ComDocument
{

    [MenuItem("Assets/Create/Document/txt")]
    public static void CreateTXT()
    {

        Dictionary<string, string> dic = new Dictionary<string, string>();

        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);

        string pathRes = AssetDatabase.GetAssetPath(arr[0]);
        Debug.Log("filePath=" + pathRes);

        string pathIni = pathRes + "/新建文件.txt";
        if (File.Exists(pathIni))
        {
            File.Delete(pathIni);
        }

        CreateResInfo(pathRes, ref dic);
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> keyValue in dic)
        {
            list.Add(keyValue.Key + "=" + keyValue.Value);
        }
        StreamWriter sw = new StreamWriter(pathRes + "/新建文件.txt");
        sw.Close();   //释放掉

        AssetDatabase.Refresh();
        //File.WriteAllLines(pathRes + "/新建文件.txt", list.ToArray());
        Debug.Log("生成完毕 ");
        AssetDatabase.Refresh();
    }
    [MenuItem("Assets/Create/Document/doc")]
    public static void CreateWord()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);

        string pathRes = AssetDatabase.GetAssetPath(arr[0]);
        Debug.Log("filePath=" + pathRes);

        string pathIni = pathRes + "/新建文件.doc";
        if (File.Exists(pathIni))
        {
            File.Delete(pathIni);
        }

        CreateResInfo(pathRes, ref dic);
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> keyValue in dic)
        {
            list.Add(keyValue.Key + "=" + keyValue.Value);
        }
        StreamWriter sw = new StreamWriter(pathRes + "/新建文件.doc");
        sw.Close();   //释放掉
        AssetDatabase.Refresh();
        //File.WriteAllLines(pathRes + "/新建文件.doc", list.ToArray());
        Debug.Log("生成完毕 ");
        AssetDatabase.Refresh();
    }
    [MenuItem("Assets/Create/Document/ppt")]
    public static void CreatePPT()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);

        string pathRes = AssetDatabase.GetAssetPath(arr[0]);
        Debug.Log("filePath=" + pathRes);

        string pathIni = pathRes + "/新建文件.ppt";
        if (File.Exists(pathIni))
        {
            File.Delete(pathIni);
        }

        CreateResInfo(pathRes, ref dic);
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> keyValue in dic)
        {
            list.Add(keyValue.Key + "=" + keyValue.Value);
        }
        StreamWriter sw = new StreamWriter(pathRes + "/新建文件.ppt");
        sw.Close();   //释放掉
        AssetDatabase.Refresh();
        //File.WriteAllLines(pathRes + "/新建文件.ppt", list.ToArray());
        Debug.Log("生成完毕 ");
        AssetDatabase.Refresh();
    }

    [MenuItem("Assets/Create/Document/excel")]
    public static void CreateExcel()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);

        string pathRes = AssetDatabase.GetAssetPath(arr[0]);
        Debug.Log("filePath=" + pathRes);

        string pathIni = pathRes + "/新建文件.xls";
        if (File.Exists(pathIni))
        {
            File.Delete(pathIni);
        }

        CreateResInfo(pathRes, ref dic);
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> keyValue in dic)
        {
            list.Add(keyValue.Key + "=" + keyValue.Value);
        }
        StreamWriter sw = new StreamWriter(pathRes + "/新建文件.xls");
        sw.Close();   //释放掉
        AssetDatabase.Refresh();
        //File.WriteAllLines(pathRes + "/新建文件.xls", list.ToArray());
        Debug.Log("生成完毕 ");
        AssetDatabase.Refresh();
    }



    public static void CreateResInfo(string path, ref Dictionary<string, string> dic)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            return;
        }
        FileInfo[] files = dir.GetFiles();
        for (int i = 0; i < files.Length; i++)
        {

            FileInfo info = files[i];
            if (!(info.Name.IndexOf(".meta", 0) > 0))
            {

                string pathdir = info.FullName.Replace("\\", "/")
                    .Replace((Application.dataPath + "/Resources/"), "")
                    .Replace(info.Name, "").TrimEnd('/');
                string fileName = Path.GetFileNameWithoutExtension(info.Name);
                Debug.Log("fileName =" + fileName);
                if (!dic.ContainsKey(info.Name))
                {
                    dic.Add(fileName, pathdir);
                }
                else
                {
                    Debug.Log("存在相同的资源名称 名称为：" + info.Name + "/path1=" + dic[info.Name] + "/ path2 =" + pathdir);
                }
            }
        }
        DirectoryInfo[] dirs = dir.GetDirectories();
        if (dirs.Length > 0)
        {
            for (int i = 0; i < dirs.Length; i++)
            {
                string tempPath = Path.Combine(path, dirs[i].Name);
                CreateResInfo(tempPath, ref dic);
            }
        }
    }
}