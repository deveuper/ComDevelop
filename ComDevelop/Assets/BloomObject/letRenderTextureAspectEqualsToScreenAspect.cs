using UnityEngine;
using System.Collections;
public class letRenderTextureAspectEqualsToScreenAspect : MonoBehaviour
{
    public RenderTexture m_rt;
    // Use this for initialization
    void Start()
    {
        float screenAspect = (float)(Screen.width) / Screen.height;
        ////Debug.Log (screenAspect);
        m_rt.width = (int)(m_rt.height * screenAspect);
    }
}