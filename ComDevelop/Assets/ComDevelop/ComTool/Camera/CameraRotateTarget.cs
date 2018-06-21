using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace ComDevelop.ComTool
{
    public class CameraRotateTarget : MonoBehaviour
    {
        [Tooltip("the control platform")]
        public Platforms TargetPlatform = Platforms.PC_Mouse;
        [Tooltip("the rotating target")]
        public Transform targetObject;
        //save the target transform information in it
        private GameObject target;
        [Tooltip("the camera to see target")]
        public Transform viewCamera;
        [Tooltip("the distance between camera and target on starting time")]
        public float startDistance = 5.0f;
        [Tooltip("X axis speed")]
        public float xSpeed = 20.0f;
        [Tooltip("Y axis speed")]
        public float ySpeed = 20.0f;
        [Tooltip("")]
        public float yMinLimit = -5f;
        [Tooltip("")]
        public float yMaxLimit = 60f;
        [Tooltip("Min distance for camera")]
        public float distanceMin = .5f;
        [Tooltip("Max distance for camera")]
        public float distanceMax = 15f;
        [Tooltip("smooth value in every frame")]
        public float smoothTime = 2f;
        float rotationYAxis = 0.0f;
        float rotationXAxis = 0.0f;
        float velocityX = 0.0f;
        float velocityY = 0.0f;


        //for touch point
        private Vector2 previousPos1;
        private Vector2 previousPos2;
        private Vector2 currentPos1;
        private Vector2 CurrentPos2;

        //
        private TouchDirection currentDir = TouchDirection.None;

        // Use this for initialization
        void Start()
        {
            Vector3 angles = viewCamera.eulerAngles;
            rotationYAxis = angles.y;
            rotationXAxis = angles.x;
            // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }

            target = new GameObject("CursorCenter");
            target.transform.position = targetObject.position;
            target.transform.rotation = targetObject.rotation;
        }
        void LateUpdate()
        {
            //if (target)
            //修改，添加点击时，不穿透UI的条件
            if (target && EventSystem.current.IsPointerOverGameObject() == false)
            {
                ChoosePlatform();
                RaycastPoint();
            }
        }
        //Move to point 
        private void MovePoint()
        {

        }


        private void ChoosePlatform()
        {
            switch (TargetPlatform)
            {
                case Platforms.PC_Mouse:
                    RotateTargetMouse();
                    break;
                case Platforms.PC_Windos_Touch:
                    RotateTargetMouse();
                    break;
                case Platforms.Moblie_Touch:
                    RotateTargetTouch();
                    break;
                default:
                    break;
            }
        }

        private void RotateTargetMouse()
        {

            //PC Version--using mouse control
            if (Input.GetMouseButton(0))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * startDistance * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            }

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            startDistance = Mathf.Clamp(startDistance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            RaycastHit hit;
            //if (Physics.Linecast(target.position, transform.position, out hit))
            //{
            //    startDistance -= hit.distance;
            //}
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -startDistance);
            Vector3 position = rotation * negDistance + target.transform.position;

            viewCamera.rotation = rotation;
            viewCamera.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);

        }
        private void RotateTargetTouch()
        {

            //Android & ios version -- using touch control
            if (Input.touchCount == 0)
            {
                previousPos1 = currentPos1 = Vector2.zero;
            }

            if (Input.touchCount == 1)
            {
                currentPos1 = Input.GetTouch(0).position;
                if (previousPos1 != Vector2.zero)
                {
                    switchDirection(currentPos1, previousPos1);
                }
                previousPos1 = currentPos1;
            }

        }
        private void TouchScroll()
        {
            switch (currentDir)
            {
                case TouchDirection.Right:
                    break;
                case TouchDirection.Left:
                    break;
                case TouchDirection.Up:
                    break;
                case TouchDirection.Down:
                    break;
                case TouchDirection.None:
                    break;
                default:
                    break;
            }

        }


        private Vector3 distanceVector3;

        private void switchDirection(Vector2 cPos, Vector2 pPos)
        {
            //the Horizontal Axis
            if (Mathf.Abs(cPos.x - pPos.x) > Mathf.Abs(cPos.y - pPos.y))
            {
                if (cPos.x - pPos.x > 0)
                {
                    currentDir = TouchDirection.Right;

                }


                if (cPos.x - pPos.x < 0) currentDir = TouchDirection.Left;
            }
            //the Vertical Axis
            else
            {
                if (cPos.y - pPos.y > 0) currentDir = TouchDirection.Up;
                if (cPos.y - pPos.y < 0) currentDir = TouchDirection.Down;
            }

            distanceVector3 = new Vector3(cPos.x - pPos.x, cPos.y - pPos.y, 0);

            //means control finger move up,target to rotate AxisX
            rotationXAxis += distanceVector3.y;
            //means control finger move right,target to rotate AxisY
            rotationYAxis -= distanceVector3.x;//use the anti direction cause negative number 
            //just rotate target between 180 to -180
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);

            Vector3 negDistance = new Vector3(0, 0, -startDistance);
            //camera new position
            Vector3 tempPos = toRotation * negDistance + target.transform.position;

            viewCamera.rotation = toRotation;
            viewCamera.position = tempPos;
            //Trail compute
            distanceVector3.x = Mathf.Lerp(distanceVector3.x, 0, Time.deltaTime * smoothTime);
            distanceVector3.y = Mathf.Lerp(distanceVector3.y, 0, Time.deltaTime * smoothTime);

        }



        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }
        #region move camera to new target
        //move Camera rotate a new target 
        //*******************************
        public LayerMask objectLayer;

        private Vector3 mouseDownPos;

        private Vector3 hitPosition;

        //create a point on hit position
        public GameObject PointCursor;
        private void RaycastPoint()
        {
            Vector3 vectorOriginDir = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                mouseDownPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Vector3.Distance(Input.mousePosition, mouseDownPos) < 0.6f)
                {
                    vectorOriginDir = target.transform.position - Camera.main.transform.position;

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 10000, objectLayer))
                    {
                        hitPosition = hit.point;
                        Vector3 vectorTarget = hitPosition - vectorOriginDir;
                        PointCursor.transform.position = hitPosition;
                        PointCursor.SetActive(true);
                    }
                }
            }
            if (target.transform.position != hitPosition && hitPosition != Vector3.zero)
            {
                target.transform.position = Vector3.Lerp(target.transform.position, hitPosition, Time.deltaTime * 5f);
            }
            if (Vector3.Distance(target.transform.position, hitPosition) <= 0.5f)
            {
                PointCursor.SetActive(false);
            }

        }

        //*******************************
        #endregion


        /// <summary>
        /// Using different control-method for platforms  
        /// </summary>
        public enum Platforms
        {
            PC_Mouse,
            PC_Windos_Touch,
            Moblie_Touch
        }

        /// <summary>
        /// Touch moving direction
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
