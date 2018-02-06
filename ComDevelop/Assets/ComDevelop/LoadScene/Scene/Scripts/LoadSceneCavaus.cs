using ComDevelop.ComTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ComDevelop.LocaScene
{
    /// <summary>
    /// 画布明暗切换场景
    /// </summary>
    [Serializable]
    public class LoadSceneCanvas : BaseLoadScene
    {
        public override void Loading()
        {
            ComUI.UIManager.Instance.fadePanel.fadeSpeed = loadingSpeed;
            ComUI.UIManager.Instance.fadePanel.InternalWaitTime = internalTime;
            if (ComUI.UIManager.Instance.fadePanel.cGroup.alpha >= 0.9f)
            {
                CameraShow.SetActive(true);
            }
            if (!ComUI.UIManager.Instance.fadePanel.inProgress && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
                for (int i = 0; i < DoNotDestroyOnLoad_Com.FristNotDestoryObjList.Count; i++)
                {
                    GameObject.Destroy(DoNotDestroyOnLoad_Com.FristNotDestoryObjList[i].gameObject);
                }

            }
        }
    }
}
