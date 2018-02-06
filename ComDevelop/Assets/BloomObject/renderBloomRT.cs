using UnityEngine;
using System.Collections;
using System;

public class renderBloomRT : MonoBehaviour
{
    public Camera m_mainCameraRef;
    public Shader m_renderBloomTexShader;
    private void Start()
    {
        GetComponent<Camera>().enabled = false;

        synchronizePosAndRotWithMainCamera();

        synchronizeProjModeAndFrustomWithMainCamera();
    }

    private void synchronizeProjModeAndFrustomWithMainCamera()
    {
        GetComponent<Camera>().orthographic = m_mainCameraRef.orthographic;
        GetComponent<Camera>().orthographicSize = m_mainCameraRef.orthographicSize;
        GetComponent<Camera>().nearClipPlane = m_mainCameraRef.nearClipPlane;
        GetComponent<Camera>().farClipPlane = m_mainCameraRef.farClipPlane;
        GetComponent<Camera>().fieldOfView = m_mainCameraRef.fieldOfView;
    }

    private void synchronizePosAndRotWithMainCamera()
    {
        transform.position = m_mainCameraRef.transform.position;
        transform.rotation = m_mainCameraRef.transform.rotation;
    }

    private void Update()
    {
        synchronizePosAndRotWithMainCamera();
        //Rendering with Replaced Shaders: http://www.cnblogs.com/wantnon/p/4528677.html
        GetComponent<Camera>().RenderWithShader(m_renderBloomTexShader, "RenderType");
    }
}
