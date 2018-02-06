using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ComDevelop.ComTool
{
    public class CameraMovement : MonoBehaviour
    {
        public float Smooth = 1.5f;
        public Transform Target;
        private Vector3 _relativeCameraPosition;
        private Vector3 _newCameraPosition;
        private float cameraPositionMessage;

        private void Awake()
        {
            if (Target == null)
            {
                Target = GameObject.FindGameObjectWithTag("Player").transform;

                _relativeCameraPosition = transform.position - Target.position;//the relative position for current camera
                cameraPositionMessage = _relativeCameraPosition.magnitude - 0.5f;//the distance between target and camera
            }
        }
        private void FixedUpdate()
        {
            Vector3 StartPosition = Target.position + _relativeCameraPosition;
            Vector3 AbovePosition = Target.position + Vector3.up * cameraPositionMessage;
            transform.position = Vector3.Lerp(transform.position, StartPosition, Smooth * Time.deltaTime);
            //SmoothLookAt();
        }
        void SmoothLookAt()
        {
            Vector3 relPlayerPosition = Target.position - transform.position;

            Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Smooth * Time.deltaTime);
        }
    }
}