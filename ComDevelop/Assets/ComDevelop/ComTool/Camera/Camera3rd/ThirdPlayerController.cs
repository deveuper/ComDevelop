using UnityEngine;

public class ThirdPlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("移动速度 | Movement speed")]
    public float moveSpeed = 5.0f;
    
    [Tooltip("旋转速度 | Rotation speed")]
    public float rotateSpeed = 25f;
    
    [Tooltip("到达目标点的停止距离 | Stop distance to target")]
    public float stoppingDistance = 0.1f;
    
    [Header("Click Settings")]
    [Tooltip("点击移动的层级 | Layer mask for click movement")]
    public LayerMask movementLayer;
    
    [Tooltip("点击位置指示器 | Click position indicator")]
    public GameObject moveIndicator;

    [Header("Movement Smoothing")]
    [Tooltip("位置跟随的平滑时间 | Position follow smooth time")]
    public float positionSmoothTime = 0.15f;
    
    [Tooltip("旋转跟随的平滑时间 | Rotation follow smooth time")]
    public float rotationSmoothTime = 0.1f;

    // 内部变量
    private Vector3 targetPosition;
    private bool isMoving;
    private Camera mainCamera;

    // 用于平滑移动的速度变量
    private Vector3 currentVelocity;
    private float currentRotationVelocity;

    // 上一帧的时间
    private float lastFrameTime;
    // 固定的时间步长
    private const float FIXED_TIME_STEP = 0.02f; // 50fps为基准

    private void Start()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
        lastFrameTime = Time.time;
        
        // 如果有指示器，初始时隐藏
        if (moveIndicator) 
        {
            moveIndicator.SetActive(false);
        }

        // 设置最大帧率以避免过高帧率导致的问题
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        // 处理键盘输入
        HandleKeyboardInput();
        
        // 处理鼠标点击
        HandleMouseInput();
        
        // 处理移动和旋转
        HandleMovement();
    }

    private void HandleKeyboardInput()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.D))
            moveDirection += transform.right;
        if (Input.GetKey(KeyCode.A))
            moveDirection -= transform.right;
        if (Input.GetKey(KeyCode.E))
            moveDirection -= transform.up;
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Space))
            moveDirection += transform.up;

        // 如果有键盘输入，取消鼠标点击移动
        if (moveDirection != Vector3.zero)
        {
            isMoving = false;
            if (moveIndicator) moveIndicator.SetActive(false);
            
            // 标准化方向并应用移动
            moveDirection.Normalize();
            // 使用MoveTowards确保一致的移动速度
            transform.position = Vector3.MoveTowards(
                transform.position,
                transform.position + moveDirection,
                moveSpeed * Time.deltaTime);
        }
    }

    private void HandleMouseInput()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, movementLayer))
            {
                // 设置目标位置
                targetPosition = hit.point;
                isMoving = true;

                // 显示移动指示器
                if (moveIndicator)
                {
                    moveIndicator.transform.position = hit.point;
                    moveIndicator.SetActive(true);
                }
            }
        }
    }

    private void HandleMovement()
    {
        if (!isMoving) return;

        // 计算时间增量
        float deltaTime = Time.time - lastFrameTime;
        lastFrameTime = Time.time;
        
        // 限制deltaTime的最大值，防止大延迟
        deltaTime = Mathf.Min(deltaTime, 0.1f);
        
        // 计算到目标的方向和距离
        Vector3 directionToTarget = targetPosition - transform.position;
        float distanceToTarget = directionToTarget.magnitude;
        
        // 如果距离大于停止距离，继续移动
        if (distanceToTarget > stoppingDistance)
        {
            // 计算移动方向
            Vector3 moveDirection = directionToTarget.normalized;
            
            // 计算目标旋转
            Vector3 flatDirection = new Vector3(moveDirection.x, 0, moveDirection.z).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
            
            // 使用SmoothDamp进行平滑移动
            Vector3 newPosition = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref currentVelocity,
                positionSmoothTime,
                moveSpeed,
                deltaTime);

            // 加快旋转速度的平滑处理
            float currentYAngle = transform.eulerAngles.y;
            float targetYAngle = targetRotation.eulerAngles.y;
            float newYAngle = Mathf.SmoothDampAngle(
                currentYAngle,
                targetYAngle,
                ref currentRotationVelocity,
                rotationSmoothTime,
                rotateSpeed * 2f,
                deltaTime);

            // 应用移动和旋转
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(0, newYAngle, 0);

            // 计算实际移动速度
            float actualSpeed = (newPosition - transform.position).magnitude / deltaTime;
            
            // 如果速度过慢且距离较远，进行直接移动
            if (actualSpeed < moveSpeed * 0.1f && distanceToTarget > 1f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    moveSpeed * deltaTime);
            }
        }
        else
        {
            // 到达目标点
            isMoving = false;
            if (moveIndicator) moveIndicator.SetActive(false);
            
            // 清除速度
            currentVelocity = Vector3.zero;
            currentRotationVelocity = 0f;
        }
    }

    // 绘制移动路径（仅在编辑器中可见）
    private void OnDrawGizmos()
    {
        if (isMoving)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, targetPosition);
            Gizmos.DrawWireSphere(targetPosition, 0.3f);
        }
    }
}
