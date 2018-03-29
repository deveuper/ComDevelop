using UnityEngine;
using System.Collections;

namespace ComDevelop.ComTool
{
    public class MouseScrollTarget : MonoBehaviour
    {
        [Tooltip("the target with mouse")]
        public Transform target;
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
        // Use this for initialization
        void Start()
        {
            Vector3 angles = transform.eulerAngles;
            rotationYAxis = angles.y;
            rotationXAxis = angles.x;
            // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
        }
        void LateUpdate()
        {
            if (target)
            {
                //PC Version--using mouse control
                if (Input.GetMouseButton(1))
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
                Vector3 position = rotation * negDistance + target.position;

                transform.rotation = rotation;
                transform.position = position;
                velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
                velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
            }
        }
        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }
    }
}