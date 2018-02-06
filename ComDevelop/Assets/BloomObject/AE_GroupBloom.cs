using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AE_GroupBloom : MonoBehaviour {

    public Material m_groupBloomMaterial;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_groupBloomMaterial); 
    }
}
