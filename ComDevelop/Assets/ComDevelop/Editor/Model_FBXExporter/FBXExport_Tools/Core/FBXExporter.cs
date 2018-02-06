using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using ComDevelop.EditorTool.FBXTool;

public class FBXExporter
{
    private static string GetUniqueName(string name, string path, string extension)
    {
        string path2 = string.Concat(new string[]
        {
            Application.dataPath,
            path,
            "/",
            name,
            extension
        });
        int num = 1;
        bool flag = !File.Exists(path2);
        string result;
        if (flag)
        {
            result = name;
        }
        else
        {
            while (true)
            {
                path2 = string.Concat(new object[]
                {
                    Application.dataPath,
                    path,
                    "/",
                    name,
                    " ",
                    num,
                    extension
                });
                bool flag2 = !File.Exists(path2);
                if (flag2)
                {
                    break;
                }
                num++;
            }
            name = name + " " + num;
            result = name;
        }
        return result;
    }

    private static void SetDirectories(string folderPathForFBX)
    {
        bool flag = !Directory.Exists(Application.dataPath + folderPathForFBX);
        if (flag)
        {
            Directory.CreateDirectory(Application.dataPath + folderPathForFBX);
        }
    }

    private static List<Material> GetUniqueMaterials(GameObject[] objectsToCombine)
    {
        List<Material> list = new List<Material>();
        for (int i = 0; i < objectsToCombine.Length; i++)
        {
            Material[] sharedMaterials = objectsToCombine[i].GetComponent<Renderer>().sharedMaterials;
            for (int j = 0; j < sharedMaterials.Length; j++)
            {
                Material item = sharedMaterials[j];
                bool flag = !list.Contains(item);
                if (flag)
                {
                    list.Add(item);
                }
            }
        }
        return list;
    }

    private static GameObject DuplicateObject(GameObject objectToDuplicate)
    {
        GameObject gameObject = GameObject.Instantiate<GameObject>(objectToDuplicate);
        gameObject.transform.parent = (objectToDuplicate.transform.parent);
        gameObject.transform.localPosition = objectToDuplicate.transform.localPosition;
        gameObject.transform.localEulerAngles = objectToDuplicate.transform.localEulerAngles;
        gameObject.transform.localScale = objectToDuplicate.transform.localScale;
        gameObject.transform.parent = null;
        gameObject.name = objectToDuplicate.name;
        return gameObject;
    }

    private static void BuildAndSaveFBX(string folderPathForFBX, string fbxName, GameObject topParent, Material[] materials)
    {
        string text = string.Concat(new string[]
        {
            Application.dataPath,
            folderPathForFBX,
            "/",
            fbxName,
            ".fbx"
        });
        string contents = FBXWriter.MeshToString(topParent, text, materials, true, true);
        File.WriteAllText(text, contents);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private static void ExportFBXForTheseObjects(GameObject[] objectsToCombine, string folderPathForFBX, string fbxName, bool addObjectInHierarchy, GameObject parentGameobject)
    {
        List<Material> list = new List<Material>();
        list = FBXExporter.GetUniqueMaterials(objectsToCombine);
        GameObject gameObject;
        if (addObjectInHierarchy)
        {
            gameObject = FBXExporter.DuplicateObject(parentGameobject);
        }
        else
        {
            bool flag = objectsToCombine.Length == 1;
            if (flag)
            {
                gameObject = FBXExporter.DuplicateObject(objectsToCombine[0]);
            }
            else
            {
                gameObject = new GameObject(fbxName);
                for (int i = 0; i < objectsToCombine.Length; i++)
                {
                    GameObject gameObject2 = FBXExporter.DuplicateObject(objectsToCombine[i]);
                    gameObject2.transform.parent = gameObject.transform;
                }
            }
        }
        gameObject.name = fbxName;
        FBXExporter.BuildAndSaveFBX(folderPathForFBX, fbxName, gameObject, list.ToArray());
        GameObject.DestroyImmediate(gameObject);
    }

    public static void ExportFBX(string folderPathForFBX, string fbxName, GameObject[] selectedObjects, bool addObjectInHierarchy)
    {
        fbxName = FBXExporter.GetUniqueName(fbxName, folderPathForFBX, ".fbx");
        bool flag = FBXExporter.ErrorCheckings(selectedObjects, addObjectInHierarchy) != 0;
        if (!flag)
        {
            GameObject[] objectsToCombine = FBXExporter.GetObjectsToCombine(selectedObjects, addObjectInHierarchy);
            FBXExporter.SetDirectories(folderPathForFBX);
            FBXExporter.ExportFBXForTheseObjects(objectsToCombine, folderPathForFBX, fbxName, addObjectInHierarchy, selectedObjects[0]);
        }
    }

    private static int ErrorCheckings(GameObject[] selectedObjects, bool addObjectInHierarchy)
    {
        int result = 0;
        bool flag = selectedObjects == null;
        if (flag)
        {
            Debug.LogError("Nothing Selected!!!");
            result = -1;
        }
        else
        {
            bool flag2 = selectedObjects.Length == 0;
            if (flag2)
            {
                Debug.LogError("Nothing Selected!!!");
                result = -1;
            }
            else
            {
                bool flag3 = addObjectInHierarchy && selectedObjects.Length > 1;
                if (flag3)
                {
                    Debug.LogError("Select only one Gameobject if using heirarchy");
                    result = -1;
                    result = 0;
                }
            }
        }
        return result;
    }

    public static GameObject[] GetObjectsToCombine(GameObject[] selectedObjects, bool addObjectInHierarchy)
    {
        List<MeshFilter> list = new List<MeshFilter>();
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            if (addObjectInHierarchy)
            {
                MeshFilter[] componentsInChildren = selectedObjects[i].GetComponentsInChildren<MeshFilter>();
                for (int j = 0; j < componentsInChildren.Length; j++)
                {
                    bool flag = componentsInChildren[j].sharedMesh;
                    if (flag)
                    {
                        bool flag2 = componentsInChildren[j].GetComponent<Renderer>();
                        if (flag2)
                        {
                            bool flag3 = componentsInChildren[j].GetComponent<Renderer>().material.mainTexture;
                            if (flag3)
                            {
                                list.Add(componentsInChildren[j]);
                            }
                        }
                    }
                }
            }
            else
            {
                bool flag4 = selectedObjects[i].GetComponent<MeshFilter>();
                if (flag4)
                {
                    bool flag5 = selectedObjects[i].GetComponent<MeshFilter>().sharedMesh;
                    if (flag5)
                    {
                        bool flag6 = selectedObjects[i].GetComponent<Renderer>();
                        if (flag6)
                        {
                            bool flag7 = selectedObjects[i].GetComponent<Renderer>().sharedMaterial.mainTexture;
                            if (flag7)
                            {
                                list.Add(selectedObjects[i].GetComponent<MeshFilter>());
                            }
                        }
                    }
                }
            }
        }
        List<MeshFilter> list2 = new List<MeshFilter>();
        foreach (MeshFilter current in list)
        {
            bool flag8 = !list2.Contains(current);
            if (flag8)
            {
                list2.Add(current);
            }
        }
        GameObject[] array = new GameObject[list2.Count];
        for (int i = 0; i < list2.Count; i++)
        {
            array[i] = list2[i].gameObject;
        }
        return array;
    }
}
