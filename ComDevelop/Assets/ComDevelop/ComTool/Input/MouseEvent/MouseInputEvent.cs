using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace ComDevelop.ComTool
{
    public class MouseInputEvent : MonoBehaviour, IPointerEnterHandler,IPointerDownHandler,IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
    {
        public float interval = 0.1f;

        [SerializeField]

        UnityEvent m_OnLongpress = new UnityEvent();
        private bool isPointDown = false;
        private float lastInvokeTime;

        private void Update()
        {
            OnLongPointDown();
        }

        /// <summary>
        /// 长时间按下
        /// </summary>
        public void OnLongPointDown()
        {
            if (isPointDown)
            {
                if (Time.time - lastInvokeTime > interval)
                {
                    //调用所有的注册的回调 
                    m_OnLongpress.Invoke();

                    lastInvokeTime = Time.time;

                    Debug.Log("长按");
                }
            }
        }
        /// <summary>
        /// 按下的事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            m_OnLongpress.Invoke();

            isPointDown = true;

            lastInvokeTime = Time.time;

            Debug.Log("鼠标按下");

        }

        /// <summary>
        /// 抬起的事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            isPointDown = false;
            Debug.Log("鼠标抬起");
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointDown = false;
            Debug.Log("鼠标进入");
        }
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            isPointDown = false;
            Debug.Log("鼠标退出");
        }
        /// <param name="eventData"></param>
        /// <summary>
        /// 点击事件
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            isPointDown = false;
            Debug.Log("鼠标点击");
        }

    }
}
