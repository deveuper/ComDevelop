
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
    [MenuItem("Assets/Create/C#GameScript", false, 75)]
    public static void CreateCSharp()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);

        string pathRes = AssetDatabase.GetAssetPath(arr[0]);
        Debug.Log("filePath=" + pathRes);

        string pathIni = pathRes + "/" + NameCSharp + ".cs";
        IsContainFile(pathRes, pathIni);
        //if (File.Exists(pathIni))
        //{
        //    //File.Delete(pathIni);
        //    NameCSharp = NameCSharp + (index + 1).ToString();
        //    index++;
        //}

        CreateCSharpInfo(pathRes, ref dic);
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, string> keyValue in dic)
        {
            list.Add(keyValue.Key + "=" + keyValue.Value);
        }
        StreamWriter sw = new StreamWriter(pathRes + "/" + NameCSharp + ".cs");
        sw.Close();   //释放掉
        AssetDatabase.Refresh();

        string[] newStr = new string[] { "using UnityEngine;\r\nusing System.Collections;\r\n\r\n/// <summary>\r\n///\r\n/// </summary> \r\npublic class " + NameCSharp + " : MonoBehaviour \r\n{        \r\n    //初始调用        \r\n    void Awake()\r\n    {\r\n        \r\n    }\r\n    // 开始调用\r\n    void Start()\r\n    {\r\n        \r\n    }\r\n    // 每帧调用\r\n    void Update()\r\n    {\r\n\r\n    }\r\n}\r\n" };

        File.WriteAllLines(pathRes + "/" + NameCSharp + ".cs", newStr);


        Debug.Log("生成完毕 ");


        AssetDatabase.Refresh();
    }
    private static void IsContainFile(string pathRes, string pathIni)
    {

        if (File.Exists(pathIni))
        {
            if (NameCSharp[NameCSharp.Length - 1].ToString() == index.ToString())
            {
                NameCSharp = NameCSharp.Replace(index.ToString().ToCharArray()[0], (index + 1).ToString().ToCharArray()[0]) + (index + 1).ToString();
            }
            else
            {
                NameCSharp = NameCSharp + (index + 1).ToString();
            }
            index++;
            pathIni = pathRes + "/" + NameCSharp + ".cs";
            IsContainFile(pathRes, pathIni);
        }
        else
        {
            return;
        }
    }
    public static string NameCSharp = "ComScript";
    public static int index = 0;

    public static void CreateCSharpInfo(string path, ref Dictionary<string, string> dic)
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
                    //NameCSharp = NameCSharp + (index + 1).ToString();
                    //Debug.Log("存在相同的资源名称 名称为：" + info.Name + "/path1=" + dic[info.Name] + "/ path2 =" + pathdir);
                }
            }
        }
        DirectoryInfo[] dirs = dir.GetDirectories();
        if (dirs.Length > 0)
        {
            for (int i = 0; i < dirs.Length; i++)
            {
                string tempPath = Path.Combine(path, dirs[i].Name);
                CreateCSharpInfo(tempPath, ref dic);
            }
        }
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