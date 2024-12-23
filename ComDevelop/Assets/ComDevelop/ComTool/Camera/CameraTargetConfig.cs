using UnityEngine;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 相机目标配置：定义物体被选中时相机的行为
    /// Camera Target Config: Defines camera behavior when object is selected
    /// </summary>
    public class CameraTargetConfig : MonoBehaviour
    {
        public enum RotationCenterType
        {
            ClickPoint,      // 以点击点为中心
            ObjectCenter,    // 以物体中心为中心
            CustomPoint      // 以自定义点为中心
        }

        [Header("Rotation Settings")]
        [Tooltip("旋转中心类型 | Rotation center type")]
        public RotationCenterType centerType = RotationCenterType.ClickPoint;

        [Tooltip("自定义旋转中心点 | Custom rotation center point")]
        public Transform customRotationPoint;

        [Header("Camera Settings")]
        [Tooltip("相机观察距离 | Camera view distance")]
        public float viewDistance = 5f;

        [Tooltip("相机移动速度 | Camera movement speed")]
        public float moveSpeed = 5f;

        [Header("Rotation Settings")]
        [Tooltip("水平旋转速度 | Horizontal rotation speed")]
        public float horizontalRotateSpeed = 20f;

        [Tooltip("垂直旋转速度 | Vertical rotation speed")]
        public float verticalRotateSpeed = 20f;

        //"旋转速度整体系数 | Overall rotation speed multiplier"
        [HideInInspector]
        public float rotationSpeedMultiplier = 1f;

        [Tooltip("相机平滑过渡时间 | Camera smooth time")]
        public float smoothTime = 2f;

        [Header("Angle Limits")]
        [Tooltip("垂直最小角度 | Minimum vertical angle")]
        public float verticalMinAngle = -5f;

        [Tooltip("垂直最大角度 | Maximum vertical angle")]
        public float verticalMaxAngle = 60f;

        [Header("Distance Limits")]
        [Tooltip("最小观察距离 | Minimum view distance")]
        public float minDistance = 2f;

        [Tooltip("最大观察距离 | Maximum view distance")]
        public float maxDistance = 10f;

        
        /// <summary>
        /// 获取旋转中心点位置
        /// Get rotation center position
        /// </summary>
        public Vector3 GetRotationCenter(Vector3 clickPoint)
        {
            switch (centerType)
            {
                case RotationCenterType.ClickPoint:
                    return clickPoint;
                case RotationCenterType.ObjectCenter:
                    return transform.position;
                case RotationCenterType.CustomPoint:
                    return customRotationPoint ? customRotationPoint.position : transform.position;
                default:
                    return clickPoint;
            }
        }
    }
} 