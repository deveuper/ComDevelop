using UnityEngine;
using UnityEditor;

using System;
namespace ComDevelop.EditorTool.ShaderTool
{
    public class MyEditor : EditorWindow
    {

        [MenuItem("Tools/ShaderEditor/ChangeShader")]
        public static void AddWindow()
        {
            //创建窗口
            MyEditor window = (MyEditor)EditorWindow.GetWindow(typeof(MyEditor), false, "ChangeShader");//false,普通窗口：可以放入Untiy面板中
            Rect wr = new Rect(0, 0, 500, 500);
            //MyEditor window = (MyEditor)EditorWindow.GetWindowWithRect(typeof(MyEditor), wr, true);//true，悬浮窗口
            window.titleContent = new GUIContent("Bug Reporter");
            window.Show();
        }

        //输入文字的内容
        private static string shaderName;
        private static float changeValue;
        //选择贴图的对象
        //private Texture texture;

        public static GameObject changeObj;
        private bool isFather = true;
        public void Awake()
        {
            //在资源中读取一张贴图
            //texture = Resources.Load("1") as Texture;
        }
        static string temp;
        //绘制窗口时调用
        void OnGUI()
        {
            GUILayout.Label("ChangeShader");
            EditorGUILayout.TextField("_SmoothnessTextureChannel");
            //输入框控件
            shaderName = EditorGUILayout.TextField("输入更改的Shader变量名:", shaderName);

            temp = EditorGUILayout.TextField("输入更改值:", temp);
            //changeValue = Single.Parse(temp);
            changeObj = EditorGUILayout.ObjectField("添加需要的模型父物体", changeObj, typeof(GameObject), true) as GameObject;

            isFather = EditorGUILayout.Toggle("是否为父物体:单个物体不勾选，父物体时勾选", isFather);

            if (GUILayout.Button("提交更改值", GUILayout.Width(200)))
            {
                ChangeShader();
            }

        }
        private void ChangeShader()
        {
            changeValue = float.Parse(temp);
            for (int i = 0; i < changeObj.transform.childCount; i++)
            {
                changeObj.transform.GetChild(i).GetComponent<Renderer>().sharedMaterial.SetFloat(shaderName, changeValue);
            }
        }

        private void ChangeAllShader(GameObject inputObj)
        {
            for (int i = 0; i < inputObj.transform.childCount; i++)
            {
                if (inputObj.transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    inputObj.transform.GetChild(i).GetComponent<Renderer>().sharedMaterial.SetFloat(shaderName, changeValue);
                }
                if (inputObj.transform.GetChild(i).childCount != 0)
                {
                    ChangeAllShader(inputObj.transform.GetChild(i).gameObject);
                }
            }
        }
        //更新
        void Update()
        {

        }

        //void OnFocus()
        //{
        //    Debug.Log("当窗口获得焦点时调用一次");
        //}

        //void OnLostFocus()
        //{
        //    Debug.Log("当窗口丢失焦点时调用一次");
        //}

        //void OnHierarchyChange()
        //{
        //    Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
        //}

        //void OnProjectChange()
        //{
        //    Debug.Log("当Project视图中的资源发生改变时调用一次");
        //}

        //void OnInspectorUpdate()
        //{
        //    //Debug.Log("窗口面板的更新");
        //    //这里开启窗口的重绘，不然窗口信息不会刷新
        //    this.Repaint();
        //}

        //void OnSelectionChange()
        //{
        //    //当窗口出去开启状态，并且在Hierarchy视图中选择某游戏对象时调用
        //    foreach (Transform t in Selection.transforms)
        //    {
        //        //有可能是多选，这里开启一个循环打印选中游戏对象的名称
        //        Debug.Log("OnSelectionChange" + t.name);
        //    }
        //}

        //void OnDestroy()
        //{
        //    Debug.Log("当窗口关闭时调用");
        //}
    }
}