using UnityEngine;
using UnityEditor;

public class CombineMesherEditor : EditorWindow
{
    [MenuItem("Tools/MeshCombineEditor")]
    public static void DoIt()
    {
        CombineMesherEditor window = (CombineMesherEditor)EditorWindow.GetWindow(typeof(CombineMesherEditor), false, "CombineMesher");
        Rect wr = new Rect(0, 0, 300, 500);
        window.Show();
    }

    //最后合并成的网格模型
    public GameObject meshFinal;
    //需要合并的模型列表
    public GameObject[] meshList;
    private void OnGUI()
    {
        GUILayout.Label("合并网格窗口");
        GUILayout.Label("将需要合并的物体放置在同一个GameObject下");

        meshFinal = EditorGUILayout.ObjectField("添加需要合并的父物体", meshFinal, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("合并网格"))
        {
            CombineMeshMethod();
        }
    }
    private void CombineMeshMethod()
    {
        if (meshFinal.Equals(null))
        {
            Debug.Log("合并失败");
            return;
        }

        //获取MeshRender;  
        MeshRenderer[] meshRenders = meshFinal.GetComponentsInChildren<MeshRenderer>();

        if (meshRenders.Length == 0)
        {
            Debug.Log("请在父节点下添加带有meshRenderer组件的物体");
            return;
        }


        //获取材质;  
        Material[] mats = new Material[meshRenders.Length];
        //将每个模型的材质，没别放入材质列表中
        for (int i = 0; i < meshRenders.Length; i++)
        {
            mats[i] = meshRenders[i].sharedMaterial;
        }
        //获取meshFilter组件
        MeshFilter[] meshFilters = meshFinal.GetComponentsInChildren<MeshFilter>();

        //合并Mesh;  

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        Matrix4x4 matrix = meshFinal.transform.worldToLocalMatrix;
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = matrix * meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        MeshRenderer mr = meshFinal.AddComponent<MeshRenderer>();
        MeshFilter mf = meshFinal.AddComponent<MeshFilter>();
        mf.mesh = Instantiate(new Mesh());
        mf.sharedMesh.CombineMeshes(combine, false);
        //mf.mesh.CombineMeshes(combine, false);
        meshFinal.SetActive(true);

        mr.sharedMaterials = mats;

        string path = EditorUtility.SaveFilePanel("MeshCombine", Application.dataPath, meshFinal.name, "asset");
        if (path.Length != 0)
        {
            string subPath = path.Substring(0, path.IndexOf("Asset"));
            path = path.Replace(subPath, "");
            AssetDatabase.CreateAsset(mf.sharedMesh, path);
            AssetDatabase.SaveAssets();
        }
    }
}