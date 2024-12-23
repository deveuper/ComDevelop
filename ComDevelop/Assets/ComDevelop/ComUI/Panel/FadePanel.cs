using System;
using System.Collections;
using UnityEngine;

namespace ComDevelop.ComUI
{
    /// <summary>
    /// 渐变面板：实现场景切换时的渐入渐出效果
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class FadePanel : UIPanel
    {
        [Header("Fade Settings")]
        public FadeType defaultFadeType = FadeType.FadeOutIn;  // 默认渐变类型
        public float fadeSpeed = 5f;
        public float InternalWaitTime = 0.5f;

        [HideInInspector] public CanvasGroup cGroup;
        [HideInInspector] public bool inProgress = true;

        /// <summary>
        /// 渐变类型
        /// </summary>
        public enum FadeType
        {
            FadeIn,             // 从透明到不透明
            FadeOut,            // 从不透明到透明
            FadeInOut,          // 从透明到不透明再到透明
            FadeOutIn          // 从不透明到透明再到不透明
        }

        protected override void Awake()
        {
            base.Awake();
            cGroup = GetComponent<CanvasGroup>();
            keepAliveOnLoad = true;  // FadePanel需要在场景加载时保持
        }

        /// <summary>
        /// 执行渐变效果
        /// </summary>
        ///         /// <param name="finalCallBack">渐变完成后的回调</param>
        /// <param name="callback">渐变过程中的回调</param>
        public IEnumerator Fade(FadeType fadeType, float waitTime = 0.5f, Action callback = null)
        {
            inProgress = true;
            
            // 根据类型初始化alpha值
            InitializeAlpha(fadeType);

            switch (fadeType)
            {
                case FadeType.FadeIn:
                    yield return FadeTo(1f);
                    break;

                case FadeType.FadeOut:
                    yield return FadeTo(0f);
                    break;

                case FadeType.FadeInOut:
                    yield return FadeTo(1f);
                    yield return new WaitForSeconds(waitTime);
                    yield return FadeTo(0f);
                    break;

                case FadeType.FadeOutIn:
                    yield return FadeTo(0f);
                    yield return new WaitForSeconds(waitTime);
                    yield return FadeTo(1f);
                    break;
            }

            inProgress = false;
            
            if(callback != null)
            {
                callback.Invoke();
            }
        }

        /// <summary>
        /// 根据渐变类型初始化alpha值
        /// </summary>
        private void InitializeAlpha(FadeType fadeType)
        {
            switch (fadeType)
            {
                case FadeType.FadeIn:
                case FadeType.FadeInOut:
                    cGroup.alpha = 0f;
                    break;
                case FadeType.FadeOut:
                case FadeType.FadeOutIn:
                    cGroup.alpha = 1f;
                    break;
            }
        }

        /// <summary>
        /// 渐变到指定alpha值
        /// </summary>
        private IEnumerator FadeTo(float targetAlpha)
        {
            float currentAlpha = cGroup.alpha;
            float elapsedTime = 0;
            
            while (elapsedTime < 1)
            {
                elapsedTime += Time.deltaTime * fadeSpeed;
                // 使用SmoothStep使过渡更加平滑
                float t = Mathf.SmoothStep(0, 1, elapsedTime);
                cGroup.alpha = Mathf.Lerp(currentAlpha, targetAlpha, t);
                yield return null;
            }
            
            // 确保最终值是精确的
            cGroup.alpha = targetAlpha;
        }

        // 为了保持向后兼容，保留原来的Fade方法
        public IEnumerator Fade(Action finalCallBack, params Action[] callback)
        {
            yield return Fade(FadeType.FadeOutIn, InternalWaitTime, finalCallBack);
            
            if (callback != null)
            {
                foreach (Action action in callback)
                {
                    if(action != null)
                    {
                        action.Invoke();
                    }
                }
            }
        }
    }
}