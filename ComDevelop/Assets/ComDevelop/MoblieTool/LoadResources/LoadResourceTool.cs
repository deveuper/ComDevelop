using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ComDevelop.MoblieTool
{
    /// <summary>
    /// 加载资源，未完成
    /// </summary>
    public class LoadResourceTool : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public static FileStream stream;
        public static string FileName;
        public static void LoadResource()
        {
            //#if UNITY_EDITOR_WIN || UNITY_STANDALONE
            //            stream = File.Open(Application.streamingAssetsPath + @"/" + dataSource + SwitchExcelType(excelType), FileMode.Open, FileAccess.Read);
            //#elif UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)                                            //判断当前程序是否运行在安卓下   
            {
                //用来存储读入的数据   
                byte[] InBytes;
                //string FileName = "jar:file://" + Application.dataPath + "!/assets/" + dataSource + SwitchExcelType(excelType);
                //WWW会自动开始读取文件
                WWW www = new WWW(FileName);
                //WWW是异步读取，所以要用循环来等待
                while (!www.isDone) { }
                //存到字节数组里   
                InBytes = www.bytes;
                //stream = BytesToStream(dataSource + SwitchExcelType(excelType), InBytes);
            }
            //#endif
        }


    }
}