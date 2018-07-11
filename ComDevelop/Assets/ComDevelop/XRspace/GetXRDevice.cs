    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ComDevelop.XR
{
    public class GetXRDevice : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        /// <summary>
        /// 获取当前设备星系
        /// </summary>
        /// <returns>返回设备名称</returns>
        public string GetCurrentXRDevice()
        {
            string model = UnityEngine.XR.XRDevice.model != null ? UnityEngine.XR.XRDevice.model : "";
            if (model.IndexOf("Rift") >= 0)
            {
                return "oculus_touch";
            }
            else
            {
                return "htc_vive";
            }
        }
    }
}