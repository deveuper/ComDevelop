using UnityEngine;
using ComDevelop.ComUI;

namespace ComDevelop.LocaScene
{
    /// <summary>
    /// 画布明暗切换场景
    /// </summary>
    [System.Serializable]
    public class LoadSceneCanvas : BaseLoadScene
    {
        public override void Loading()
        {
            if(UIManager.Instance == null || UIManager.Instance.fadePanel == null)
            {
                Debug.LogError("Fade panel not found!");
                return;
            }

            var fadePanel = UIManager.Instance.fadePanel;
            fadePanel.fadeSpeed = loadingSpeed;
            fadePanel.InternalWaitTime = internalTime;

            if (fadePanel.cGroup.alpha >= 0.9f && CameraShow != null)
            {
                CameraShow.SetActive(true);
            }

            if (!fadePanel.inProgress && operation.progress >= 0.9f)
            {
                OnLoadComplete();
                operation.allowSceneActivation = true;
            }
        }
    }
}
