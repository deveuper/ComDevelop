using UnityEngine;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 相机目标旋转控制器：实现多平台的相机旋转、缩放和目标切换功能
    /// Camera Target Rotator: Implements camera rotation, zoom and target switching for multiple platforms
    /// </summary>
    public class CameraRotateTarget : MonoBehaviour
    {
        [Header("Platform Settings")] [Tooltip("当前控制平台 | Current control platform")]
        public ControlPlatform targetPlatform = ControlPlatform.PC_Mouse;

        [Header("Target Settings")] [Tooltip("旋转的目标物体 | Target object to rotate around")]
        public Transform targetObject;

        [Tooltip("观察相机 | View camera")] public Camera viewCamera;

        [Header("Distance Settings")] [Tooltip("初始距离 | Initial distance")]
        public float startDistance = 5.0f;

        [Tooltip("最小距离 | Minimum distance")] public float distanceMin = 0.5f;
        [Tooltip("最大距离 | Maximum distance")] public float distanceMax = 15f;

        [Header("Rotation Settings")] [Tooltip("水平旋转速度 | Horizontal rotation speed")]
        public float xSpeed = 20.0f;

        [Tooltip("垂直旋转速度 | Vertical rotation speed")]
        public float ySpeed = 20.0f;

        [Tooltip("垂直最小角度 | Minimum vertical angle")]
        public float yMinLimit = -90f;

        [Tooltip("垂直最大角度 | Maximum vertical angle")]
        public float yMaxLimit = 90f;

        [Tooltip("平滑过渡时间 | Smooth transition time")]
        public float smoothTime = 2f;

        [Header("Target Selection")] [Tooltip("可选择目标的层级 | Layer mask for selectable objects")]
        public LayerMask selectableLayer;

        [Tooltip("目标指示器预制体 | Target indicator prefab")]
        public GameObject targetIndicator;

        [Header("Movement Settings")] [Tooltip("相机移动到新目标的速度 | Camera movement speed to new target")]
        public float moveSpeed = 5f;

        [Tooltip("到达目标时的最小距离 | Minimum distance when reaching target")]
        public float arrivalDistance = 0.1f;

        // 内部状态变量 | Internal state variables
        private Transform pivotTransform;
        private float currentDistance;
        private Vector2 rotation;
        private Vector2 velocity;
        private Vector3 targetPosition;
        private bool isTransitioning;
        private Transform currentTarget; // 当前旋转目标
        private Vector3 targetPoint; // 目标点位置
        private bool isMovingToTarget; // 是否正在移动到目标
        private float targetDistance; // 目标距离

        // 触摸输入状态 | Touch input states
        private TouchState touchState = new TouchState();

        // 添加新的成员变量
        private float currentRotationSpeedX = 0f;
        private float currentRotationSpeedY = 0f;

        private void Start()
        {
            InitializeCamera();
            // 初始化当前目标
            currentTarget = targetObject;
            targetPoint = currentTarget.position;
            targetDistance = startDistance;
        }

        private void LateUpdate()
        {
            if (!viewCamera) return;

            // 处理目标选择
            HandleTargetSelection();

            if (isMovingToTarget)
            {
                // 移动到新目标
                MoveToNewTarget();
            }
            else
            {
                // 正常的旋转和缩放控制
                HandlePlatformInput();
                UpdateCameraTransform();
            }
        }

        #region Initialization

        private void InitializeCamera()
        {
            // 初始化相机状态 | Initialize camera state
            if (!viewCamera) viewCamera = Camera.main;

            // 创建旋转轴心点 | Create pivot point
            pivotTransform = new GameObject("CameraRotationPivot").transform;
            pivotTransform.position = targetObject ? targetObject.position : Vector3.zero;

            // 初始化旋转角度 | Initialize rotation angles
            Vector3 angles = transform.eulerAngles;
            rotation = new Vector2(angles.y, angles.x);

            // 初始化距离 | Initialize distance
            currentDistance = startDistance;
            targetDistance = startDistance;
        }

        #endregion

        #region Input Handling

        private void HandlePlatformInput()
        {
            switch (targetPlatform)
            {
                case ControlPlatform.PC_Mouse:
                    HandleMouseInput();
                    break;
                case ControlPlatform.Mobile_Touch:
                    HandleTouchInput();
                    break;
            }
        }

        private void HandleMouseInput()
        {
            // 旋转控制 - 只在按住鼠标时更新速度
            if (Input.GetMouseButton(1))
            {
                // 获取鼠标增量
                float deltaX = Input.GetAxis("Mouse X");
                float deltaY = Input.GetAxis("Mouse Y");

                // 只有当鼠标在移动时才更新速度
                if (Mathf.Abs(deltaX) > 0.001f || Mathf.Abs(deltaY) > 0.001f)
                {
                    velocity.x = xSpeed * deltaX * 0.1f;
                    velocity.y = -ySpeed * deltaY * 0.1f;
                }
            }
            else
            {
                // 当没有按住鼠标时，速度归零
                velocity = Vector2.zero;
            }

            // 缩放控制
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                targetDistance = Mathf.Clamp(targetDistance - scroll * 5f, distanceMin, distanceMax);
            }
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount == 0)
            {
                touchState.Reset();
                velocity = Vector2.zero; // 确保触摸结束时速度归零
                return;
            }

            // 处理单指触摸
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchState.StartTouch(touch.position);
                        velocity = Vector2.zero; // 开始触摸时重置速度
                        break;

                    case TouchPhase.Moved:
                        // 如果移动距离超过阈值，则视为拖动而不是点击
                        if (Vector2.Distance(touch.position, touchState.startPosition) > 5f)
                        {
                            Vector2 delta = touch.position - touchState.previousPosition;
                            // 直接设置速度而不是累加
                            velocity.x = xSpeed * delta.x * 0.1f;
                            velocity.y = -ySpeed * delta.y * 0.1f;
                        }

                        touchState.UpdatePosition(touch.position);
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        velocity = Vector2.zero; // 触摸结束时重置速度
                        break;
                }
            }
            // 处理双指缩放
            else if (Input.touchCount == 2)
            {
                HandlePinchZoom();
            }
        }

        private void HandlePinchZoom()
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            float previousDistance = Vector2.Distance(touchState.previousPosition, touchState.previousPosition2);
            float currentPinchDistance = Vector2.Distance(touch1.position, touch2.position);

            float deltaDistance = (currentPinchDistance - previousDistance) * 0.05f; // 增加缩放敏感度
            targetDistance = Mathf.Clamp(targetDistance - deltaDistance, distanceMin, distanceMax);

            touchState.UpdatePositions(touch1.position, touch2.position);
        }

        #endregion

        #region Camera Update

        private void UpdateCameraTransform()
        {
            // 计算目标旋转速度
            float targetSpeedX = velocity.x;
            float targetSpeedY = velocity.y;
            
            // 平滑插值当前旋转速度
            currentRotationSpeedX = Mathf.Lerp(currentRotationSpeedX, targetSpeedX, Time.deltaTime * smoothTime);
            currentRotationSpeedY = Mathf.Lerp(currentRotationSpeedY, targetSpeedY, Time.deltaTime * smoothTime);

            // 获取当前相机相对于目标点的方向
            Vector3 directionToCamera = viewCamera.transform.position - targetPoint;
            
            // 应用水平旋转
            if (Mathf.Abs(currentRotationSpeedX) > 0.001f)
            {
                viewCamera.transform.RotateAround(targetPoint, Vector3.up, currentRotationSpeedX);
            }
            
            // 应用垂直旋转（带限制）
            if (Mathf.Abs(currentRotationSpeedY) > 0.001f)
            {
                // 计算当前俯仰角
                float currentPitch = Vector3.SignedAngle(Vector3.ProjectOnPlane(directionToCamera, Vector3.up), directionToCamera, viewCamera.transform.right);
                
                // 预测下一帧的俯仰角
                float nextPitch = currentPitch + currentRotationSpeedY;
                
                // 如果下一帧角度在限制范围内，才应用旋转
                if (nextPitch >= yMinLimit && nextPitch <= yMaxLimit)
                {
                    viewCamera.transform.RotateAround(targetPoint, viewCamera.transform.right, currentRotationSpeedY);
                }
            }

            // 调整距离
            Vector3 direction = (viewCamera.transform.position - targetPoint).normalized;
            Vector3 targetPosition = targetPoint + direction * targetDistance;
            
            // 平滑移动到目标距离
            viewCamera.transform.position = Vector3.Lerp(
                viewCamera.transform.position,
                targetPosition,
                Time.deltaTime * smoothTime);

            // 始终看向目标点
            viewCamera.transform.LookAt(targetPoint);

            // 如果速度接近零，重置速度
            if (Mathf.Abs(currentRotationSpeedX) < 0.001f) currentRotationSpeedX = 0;
            if (Mathf.Abs(currentRotationSpeedY) < 0.001f) currentRotationSpeedY = 0;
        }

        #endregion

        #region Target Selection

        private void HandleTargetSelection()
        {
            if (!IsSelectInputTriggered()) return;

            // 获取线起点
            Vector2 screenPosition = GetSelectInputPosition();
            Ray ray = viewCamera.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))
            {
                // 检查是否有自定义配置
                CameraTargetConfig config = hit.collider.GetComponent<CameraTargetConfig>();

                // 重置速度和状态
                velocity = Vector2.zero;

                if (config != null)
                {
                    // 使用自定义配置
                    targetPoint = config.GetRotationCenter(hit.point);
                    targetDistance = config.viewDistance;
                    moveSpeed = config.moveSpeed;
                    smoothTime = config.smoothTime;

                    // 应用旋转速度设置
                    xSpeed = config.horizontalRotateSpeed * config.rotationSpeedMultiplier;
                    ySpeed = config.verticalRotateSpeed * config.rotationSpeedMultiplier;

                    // 应用角度限制
                    yMinLimit = config.verticalMinAngle;
                    yMaxLimit = config.verticalMaxAngle;

                    // 应用距离限制
                    distanceMin = config.minDistance;
                    distanceMax = config.maxDistance;
                }
                else
                {
                    // 使用默认配置
                    targetPoint = hit.point;
                    targetDistance = distanceMin;

                    // 恢复默认值
                    moveSpeed = 5f;
                    smoothTime = 2f;
                    xSpeed = 20f;
                    ySpeed = 20f;
                    yMinLimit = -5f;
                    yMaxLimit = 60f;
                    distanceMin = 0.5f;
                    distanceMax = 15f;
                }

                // 保存当前的旋转角度
                Vector3 currentEuler = viewCamera.transform.eulerAngles;
                rotation = new Vector2(currentEuler.y, currentEuler.x);

                isMovingToTarget = true;

                // 显示指示器
                if (targetIndicator)
                {
                    targetIndicator.transform.position = targetPoint;
                    targetIndicator.SetActive(true);
                }
            }
        }

        private bool IsSelectInputTriggered()
        {
            switch (targetPlatform)
            {
                case ControlPlatform.PC_Mouse:
                    // PC端：检查是否是短按左键
                    return Input.GetMouseButtonDown(0) &&
                           (touchState.startPosition == Vector2.zero ||
                            Vector2.Distance(Input.mousePosition, touchState.startPosition) < 5f);

                case ControlPlatform.Mobile_Touch:
                    // 移动端：检查是否是短按（点击）
                    if (Input.touchCount != 1) return false;

                    Touch touch = Input.GetTouch(0);
                    return touch.phase == TouchPhase.Ended &&
                           touch.deltaTime < 0.2f && // 触摸时间小于0.2秒
                           touch.deltaPosition.magnitude < 5f; // 移动距离小于5像素

                default:
                    return false;
            }
        }

        private Vector2 GetSelectInputPosition()
        {
            switch (targetPlatform)
            {
                case ControlPlatform.PC_Mouse:
                    return Input.mousePosition;
                case ControlPlatform.Mobile_Touch:
                    return Input.GetTouch(0).position;
                default:
                    return Vector2.zero;
            }
        }

        private void MoveToNewTarget()
        {
            // 计算目标位置
            Quaternion targetRotation = Quaternion.Euler(rotation.y, rotation.x, 0);
            Vector3 targetPosition = targetPoint - (targetRotation * Vector3.forward * targetDistance);

            // 移动相机
            viewCamera.transform.position = Vector3.Lerp(
                viewCamera.transform.position,
                targetPosition,
                Time.deltaTime * moveSpeed);

            // 旋转相机
            viewCamera.transform.rotation = Quaternion.Slerp(
                viewCamera.transform.rotation,
                targetRotation,
                Time.deltaTime * moveSpeed);

            // 检查是否到达目标
            if (Vector3.Distance(viewCamera.transform.position, targetPosition) < arrivalDistance &&
                Quaternion.Angle(viewCamera.transform.rotation, targetRotation) < 1f)
            {
                isMovingToTarget = false;

                // 隐藏指示器
                if (targetIndicator)
                {
                    targetIndicator.SetActive(false);
                }
            }
        }

        #endregion

        #region Utility

        private static float ClampAngle(float angle, float min, float max)
        {
            angle = Mathf.Repeat(angle, 360f);
            return Mathf.Clamp(angle, min, max);
        }

        #endregion

        #region Helper Classes

        private class TouchState
        {
            public Vector2 startPosition;
            public Vector2 previousPosition;
            public Vector2 previousPosition2;
            public float touchStartTime;

            public void Reset()
            {
                startPosition = previousPosition = previousPosition2 = Vector2.zero;
                touchStartTime = 0f;
            }

            public void StartTouch(Vector2 position)
            {
                startPosition = previousPosition = position;
                touchStartTime = Time.time;
            }

            public void UpdatePosition(Vector2 position)
            {
                previousPosition = position;
            }

            public void UpdatePositions(Vector2 position1, Vector2 position2)
            {
                previousPosition = position1;
                previousPosition2 = position2;
            }
        }

        public enum ControlPlatform
        {
            PC_Mouse,
            Mobile_Touch
        }

        #endregion
    }
}