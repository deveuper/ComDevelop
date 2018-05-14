using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CombineMesher : MonoBehaviour
{

    void Start()
    {
        //获取MeshRender;  
        MeshRenderer[] meshRenders = GetComponentsInChildren<MeshRenderer>();

        //材质;  
        Material[] mats = new Material[meshRenders.Length];
        for (int i = 0; i < meshRenders.Length; i++)
        {
            mats[i] = meshRenders[i].sharedMaterial;
        }

        //合并Mesh;  
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = new Mesh();
        mf.mesh.CombineMeshes(combine, false);
        gameObject.SetActive(true);
        mr.sharedMaterials = mats;
    }

}