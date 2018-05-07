using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ComDevelop.ComTool
{
    //摄像机跟随物体移动
    public class CameraFollow : MonoBehaviour
    {
        //跟随的摄像机
        public Transform cameraFollow;
        //跟随的物体
        public Transform followTarget;
        //相机跟随的缓动差值
        public float LerpValue = 10;
        //摄像机与物体的间距向量
        private Vector3 offset;
        public bool lookRotate = false;

        // Use this for initialization
        void Start()
        {
            offset = cameraFollow.position - followTarget.position;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            cameraFollow.position = Vector3.Lerp(cameraFollow.position, (offset + followTarget.position), LerpValue * Time.deltaTime);
            if (lookRotate) cameraFollow.LookAt(followTarget);
        }
    }
}