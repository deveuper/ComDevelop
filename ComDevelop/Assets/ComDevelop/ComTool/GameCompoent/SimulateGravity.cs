using UnityEngine;
using System.Collections;
namespace ComDevelop.ComTool
{
    public enum BaseState
    {
        walkingState,
        runningState,
        standingState
    }
    public class SimulateGravity : MonoBehaviour
    {
        public BaseState currentBaseState;
        public bool nextJump;
        public float moveSpeed;
        public float jumpSpeed;
        public float jumpHight;
        public float jumpVelocity;

        public bool isJumping;
        public bool isRunning;
        public bool isStanding;
        public bool isWalking;
        public bool isGround;

        public float Haxis;

        public Vector3 currentPosition;
        public Vector3 privousPosition;
        public float jumpV_x;
        // Use this for initialization
        void Start()
        {

        }

        private void LateUpdate()
        {
            //当跳跃状态==true时每帧移动相应的竖向，水平距离
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * Haxis); //角色移动实现
            if (isJumping)//跳跃实现
            {
                jumpHight += jumpVelocity * Time.deltaTime * jumpSpeed;
                jumpVelocity = jumpVelocity - 9.8f * Time.deltaTime * jumpSpeed;
                currentPosition.y = jumpHight;
                currentPosition.x = privousPosition.x + Time.deltaTime * jumpV_x; //空中水平移动实现
                transform.position = currentPosition;

            }

        }
        /// <summary>
        /// 当玩家按下跳跃键时进入跳跃状态并判断当前的水平速度
        /// </summary>
        private void Jump()
        {
            //跳跃判定
            if (Input.GetButtonDown("Jump") && nextJump)            //不能在落地前跳跃
                if (currentBaseState == BaseState.walkingState ||
                    currentBaseState == BaseState.runningState ||
                    currentBaseState == BaseState.standingState)//不能在动画完成前跳跃
                {
                    nextJump = false;//落地前无法再次起跳
                    isJumping = true;//进入跳跃状态
                    if (isStanding)
                    {
                        jumpV_x = 0;//处于站立状态时水平初速度为0
                        isStanding = false;//改变当前状态由站立到跳跃，下同
                    }
                    if (isWalking)
                    {
                        jumpV_x = Haxis * moveSpeed;
                        isWalking = false;
                    }
                    if (isRunning)                //加速跳跃
                    {
                        jumpV_x = Haxis * moveSpeed;
                        //jumpVelocity = jumpVelocity * jumpMultiple;//加速跳跃时竖向分速度也提高
                        isRunning = false;
                    }
                }
        }
        //落地以后退出跳跃状态，允许进行下次跳跃，并将跳跃速度的全局变量回归初始值以便下次跳跃

        void OnCollisionEnter(Collision collider)
        {
            //落地检测
            if (collider.gameObject.tag == "Ground")
            {
                nextJump = true;
                isGround = true;
                isJumping = false;

                //落地还原速度
                moveSpeed = moveSpeed;
                jumpVelocity = jumpVelocity;
                jumpHight = 0;
                jumpV_x = 0;

                Debug.Log("ground!");
            }
        }
        void OnCollisionExit(Collision collider)
        {
            //离地检测
            if (collider.gameObject.tag == "Ground")
                isGround = false;
            Debug.Log("offground!");
        }
    }
}