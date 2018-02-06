using UnityEngine;
using System.Collections;
namespace RealtyRoundFrame
{
    public class SandBoxCamera : MonoBehaviour
    {
        /// <summary>
        /// 发出射线的camera
        /// </summary>
        public Camera raycastCamera;
        /// <summary>
        /// 需要检测的层
        /// </summary>
        public LayerMask hitLayer;
        /// <summary>
        /// 射线检测的距离
        /// </summary>
        public float raycastDistance;
        //测试的目标
        public Transform targetRotate;

        private RaycastHit hit;

        public float RotateSpeed = 10f;

        /// <summary>
        /// 触摸的方向
        /// </summary>
        public TouchDirection touchDir = TouchDirection.None;
        [Tooltip("将Y轴滑动反向")]
        public bool IsAxisUpDownResverse = false;
        /// <summary>
        /// 位置差值
        /// </summary>
        private Vector3 durationPos;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            InputScroll();
            ScaleDistance();
        }
        //当前的位置
        private Vector3 currentPos;
        //上一个点的位置
        private Vector3 previousPos;

        public void InputScroll()
        {
            if (Input.GetMouseButton(0))
            {
                ScrollScreen();
            }
            else if (!Input.GetMouseButton(0))
            {
                previousPos = currentPos = Vector3.zero;
            }

        }

        //旋转屏幕
        public void ScrollScreen()
        {
            //Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
            ////屏幕旋转，只看UI层
            //if (Physics.Raycast(ray, raycastDistance, hitLayer))
            //{

            //Debug.Log(Input.mousePosition);
            previousPos = previousPos == Vector3.zero ? Input.mousePosition : currentPos;
            currentPos = Input.mousePosition;
            if (previousPos != currentPos)
            {
                switchDirection(currentPos);
                RotateTarget(durationPos, touchDir);
            }
            //}
        }
        /// <summary>
        /// 旋转目标
        /// </summary>
        /// <param name="rotateSpeed"></param>
        /// <param name="dir"></param>
        public void RotateTarget(Vector3 durationPos, TouchDirection dir)
        {
            float rotateValue = 0;
            float AxisUpDownDir = IsAxisUpDownResverse ? -1 : 1;
            switch (dir)
            {
                case TouchDirection.Right:
                    rotateValue = durationPos.x;
                    transform.RotateAround(targetRotate.position, Vector3.up,
                        RotateSpeed * rotateValue * Time.deltaTime);
                    break;
                case TouchDirection.Left:
                    rotateValue = durationPos.x;
                    transform.RotateAround(targetRotate.position, Vector3.up,
                        RotateSpeed * rotateValue * Time.deltaTime);
                    break;
                case TouchDirection.Up:
                    rotateValue = durationPos.y;
                    transform.RotateAround(targetRotate.position, transform.right,
                       AxisUpDownDir * RotateSpeed * rotateValue * Time.deltaTime);
                    break;
                case TouchDirection.Down:
                    rotateValue = durationPos.y;
                    transform.RotateAround(targetRotate.position, transform.right,
                        AxisUpDownDir * RotateSpeed * rotateValue * Time.deltaTime);
                    break;
                case TouchDirection.None:
                    break;
                default:
                    break;
            }
        }

        public float MinDistance = 20;
        public float MaxDistance = 100;

        public void ScaleDistance()
        {
            Vector3 vectorDir = targetRotate.position - transform.position;
            transform.position = transform.position + vectorDir * Input.GetAxis("Mouse ScrollWheel");
        }




        //获取物体
        public void InputGetTarget()
        {
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

        }
        /// <summary>
        /// 选择方向
        /// </summary>
        /// <param name="inputPos">输入当前位置</param>
        /// <returns>方向</returns>
        private TouchDirection switchDirection(Vector3 inputPos)
        {
            durationPos = inputPos - previousPos;//方向
            if (Mathf.Abs(durationPos.x) > Mathf.Abs(durationPos.y))
            {
                if (durationPos.x > 0) touchDir = TouchDirection.Right;
                if (durationPos.x < 0) touchDir = TouchDirection.Left;
            }
            else if (Mathf.Abs(durationPos.y) > Mathf.Abs(durationPos.x))
            {
                if (durationPos.y > 0) touchDir = TouchDirection.Up;
                if (durationPos.y < 0) touchDir = TouchDirection.Down;
            }
            return touchDir;
        }

        /// <summary>
        /// 触摸的方向
        /// </summary>
        public enum TouchDirection
        {
            Right,
            Left,
            Up,
            Down,
            None,
        }
    }
}
