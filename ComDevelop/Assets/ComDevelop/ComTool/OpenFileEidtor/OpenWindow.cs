using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;

public class CameraTest : MonoBehaviour
{
    public GameObject plane;

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 35), "OpenDialog"))
        {
            OpenFileName ofn = new OpenFileName();

            ofn.structSize = Marshal.SizeOf(ofn);

            ofn.filter = "All Files\0*.*\0\0";

            ofn.file = new string(new char[256]);

            ofn.maxFile = ofn.file.Length;

            ofn.fileTitle = new string(new char[64]);

            ofn.maxFileTitle = ofn.fileTitle.Length;

            ofn.initialDir = UnityEngine.Application.dataPath;//默认路径

            ofn.title = "Open Project";

            ofn.defExt = "JPG";//显示文件的类型
                               //注意 一下项目不一定要全选 但是0x00000008项不要缺少
            ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

            if (DllTest.GetOpenFileName(ofn))
            {

                StartCoroutine(WaitLoad(ofn.file));//加载图片到panle

                Debug.Log("Selected file with full path: {0}" + ofn.file);

            }

        }

    }

    IEnumerator WaitLoad(string fileName)
    {
        WWW wwwTexture = new WWW("file://" + fileName);

        Debug.Log(wwwTexture.url);

        yield return wwwTexture;

        plane.GetComponent<Renderer>().material.mainTexture = wwwTexture.texture;
    }
}