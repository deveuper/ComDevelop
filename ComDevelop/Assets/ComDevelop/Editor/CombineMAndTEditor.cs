using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class CombineTextureAndMeshEditor : EditorWindow
{
    [MenuItem("Tools/sssss")]
    static void DoIt()
    {
        CombineTextureAndMeshEditor window = (CombineTextureAndMeshEditor)EditorWindow.GetWindow(typeof(CombineTextureAndMeshEditor), false, "CombineTextureAndMeshEditor");
        Rect wr = new Rect(0, 0, 300, 400);
        window.Show();
    }

    //最后合并成的网格模型
    public GameObject meshFinal;

    private void OnGUI()
    {
        GUILayout.Label("--------------------------");
        GUILayout.Label("将需要合并的物体放置在同一个GameObject下");

        meshFinal = EditorGUILayout.ObjectField("添加需要合并的父物体", meshFinal, typeof(GameObject), true) as GameObject;

        if (meshFinal == null)
        {
            GUILayout.Label("请在父节点下添加带有meshRenderer组件的物体");
            return;
        }
        int countNum = meshFinal.transform.childCount;

        if (meshFinal != null && countNum == 0)
        {
            GUILayout.Label("请在父节点下添加带有meshRenderer组件的物体");
            return;
        }
        if (objectsToCombine == null)
        {
            objectsToCombine = new GameObject[countNum];
        }
        for (int i = 0; i < countNum; i++)
        {
            objectsToCombine[i] = meshFinal.transform.GetChild(i).gameObject;
        }

        if (GUILayout.Button("合并网格"))
        {
            Combine();
        }
    }
    public GameObject[] objectsToCombine; // The objects to combine, each should have a mesh filter and renderer with a single material.
    public bool useMipMaps = true;

    public TextureFormat textureFormat = TextureFormat.RGB24;


    private void Combine()
    {
        if (meshFinal.Equals(null))
        {
            Debug.Log("合并失败");
            return;
        }
        int size;
        int originalSize;
        int pow2;
        Texture2D combinedTexture;
        Material material;
        Texture2D texture;
        Mesh mesh;
        Hashtable textureAtlas = new Hashtable();

        if (objectsToCombine.Length > 1)
        {
            //1
            Material ss = objectsToCombine[0].GetComponent<Renderer>().material;
            Texture sst = ss.mainTexture;
            //2
            originalSize = objectsToCombine[0].GetComponent<Renderer>().material.mainTexture.width;
            pow2 = GetTextureSize(objectsToCombine);
            size = pow2 * originalSize;
            combinedTexture = new Texture2D(size, size, textureFormat, useMipMaps);

            // Create the combined texture (remember to ensure the total size of the texture isn't
            // larger than the platform supports)
            for (int i = 0; i < objectsToCombine.Length; i++)
            {
                texture = (Texture2D)objectsToCombine[i].GetComponent<Renderer>().material.mainTexture;
                if (!textureAtlas.ContainsKey(texture))
                {
                    combinedTexture.SetPixels((i % pow2) * originalSize, (i / pow2) * originalSize, originalSize, originalSize, texture.GetPixels());
                    textureAtlas.Add(texture, new Vector2(i % pow2, i / pow2));
                }
            }
            combinedTexture.Apply();

            SaveTexture(combinedTexture);

            material = new Material(objectsToCombine[0].GetComponent<Renderer>().material);
            material.mainTexture = combinedTexture;

            SaveMaterial(material);

            // Update texture co-ords for each mesh (this will only work for meshes with coords betwen 0 and 1).
            for (int i = 0; i < objectsToCombine.Length; i++)
            {
                mesh = objectsToCombine[i].GetComponent<MeshFilter>().sharedMesh;
                Vector2[] uv = new Vector2[mesh.uv.Length];
                Vector2 offset;
                if (textureAtlas.ContainsKey(objectsToCombine[i].GetComponent<Renderer>().material.mainTexture))
                {
                    offset = (Vector2)textureAtlas[objectsToCombine[i].GetComponent<Renderer>().material.mainTexture];
                    for (int u = 0; u < mesh.uv.Length; u++)
                    {
                        uv[u] = mesh.uv[u] / (float)pow2;
                        uv[u].x += ((float)offset.x) / (float)pow2;
                        uv[u].y += ((float)offset.y) / (float)pow2;
                    }
                }
                else
                {
                    // This happens if you use the same object more than once, don't do it :)
                }

                mesh.uv = uv;
                objectsToCombine[i].GetComponent<Renderer>().material = material;
            }

            // Combine each mesh marked as static
            int staticCount = 0;
            CombineInstance[] combine = new CombineInstance[objectsToCombine.Length];
            for (int i = 0; i < objectsToCombine.Length; i++)
            {
                //if (objectsToCombine[i].isStatic)
                //{
                staticCount++;
                combine[i].mesh = objectsToCombine[i].GetComponent<MeshFilter>().mesh;
                combine[i].transform = objectsToCombine[i].transform.localToWorldMatrix;
                //}
            }

            // Create a mesh filter and renderer
            //if (staticCount > 1)
            //{
            MeshFilter filter = meshFinal.AddComponent<MeshFilter>();
            MeshRenderer renderer = meshFinal.AddComponent<MeshRenderer>();
            filter.mesh = Instantiate(new Mesh());
            filter.sharedMesh.CombineMeshes(combine, false);
            renderer.material = material;

            // Disable all the static object renderers
            for (int i = 0; i < objectsToCombine.Length; i++)
            {
                //if (objectsToCombine[i].isStatic)
                //{

                //objectsToCombine[i].GetComponent<MeshFilter>().mesh = null;
                //objectsToCombine[i].GetComponent<Renderer>().material = null;
                //objectsToCombine[i].GetComponent<Renderer>().enabled = false;
                //}
                objectsToCombine[i].SetActive(false);
            }
            //}

            Resources.UnloadUnusedAssets();
            //保存mesh
            SaveMesh(filter);
        }
    }


    private int GetTextureSize(GameObject[] o)
    {
        ArrayList textures = new ArrayList();
        // Find unique textures
        for (int i = 0; i < o.Length; i++)
        {
            //3
            if (!textures.Contains(o[i].GetComponent<Renderer>().material.mainTexture))
            {
                //4
                textures.Add(o[i].GetComponent<Renderer>().material.mainTexture);
            }
        }
        if (textures.Count == 1) return 1;
        if (textures.Count < 5) return 2;
        if (textures.Count < 17) return 4;
        if (textures.Count < 65) return 8;
        // Doesn't handle more than 64 different textures but I think you can see how to extend
        return 0;
    }
    private void SaveTexture(Texture2D combinedTexture)
    {
        string path = EditorUtility.SaveFilePanel("保存贴图", Application.dataPath, meshFinal.name + "_text", "asset");
        if (path.Length != 0)
        {
            string subPath = path.Substring(0, path.IndexOf("Asset"));
            path = path.Replace(subPath, "");
            AssetDatabase.CreateAsset(combinedTexture, path);
            AssetDatabase.SaveAssets();
        }
    }

    private void SaveMaterial(Material material)
    {
        string path = EditorUtility.SaveFilePanel("保存Material", Application.dataPath, meshFinal.name+"_mat", "asset");
        if (path.Length != 0)
        {
            string subPath = path.Substring(0, path.IndexOf("Asset"));
            path = path.Replace(subPath, "");
            AssetDatabase.CreateAsset(material, path);
            AssetDatabase.SaveAssets();
        }
    }


    /// <summary>
    /// 保存mesh
    /// </summary>
    /// <param name="filter"></param>
    private void SaveMesh(MeshFilter filter)
    {
        string path = EditorUtility.SaveFilePanel("保存Mesh", Application.dataPath, meshFinal.name+"_mesh", "asset");
        if (path.Length != 0)
        {
            string subPath = path.Substring(0, path.IndexOf("Asset"));
            path = path.Replace(subPath, "");
            AssetDatabase.CreateAsset(filter.sharedMesh, path);
            AssetDatabase.SaveAssets();
        }
    }




}