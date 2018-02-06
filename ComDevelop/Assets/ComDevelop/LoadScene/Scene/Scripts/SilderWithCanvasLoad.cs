using ComDevelop.ComTool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ComDevelop.LocaScene
{
    public class SilderWithCanvasLoad :BaseLoadScene
    {
        public override void Loading()
        {
            ComUI.UIManager.Instance.fadePanel.fadeSpeed = loadingSpeed;
            ComUI.UIManager.Instance.fadePanel.InternalWaitTime = internalTime;
            if (ComUI.UIManager.Instance.fadePanel.cGroup.alpha >= 0.9f)
            {
                CameraShow.SetActive(true);
                SliderLoad();
            }

            if (!ComUI.UIManager.Instance.fadePanel.inProgress
                && operation.progress >= 0.9f
                && loadingSlider.value >= 0.9f)
            {
                operation.allowSceneActivation = true;
                for (int i = 0; i < DoNotDestroyOnLoad_Com.FristNotDestoryObjList.Count; i++)
                {
                    GameObject.Destroy(DoNotDestroyOnLoad_Com.FristNotDestoryObjList[i].gameObject);
                }
            }
        }
        private void SliderLoad()
        {
            targetValue = operation.progress;

            if (operation.progress >= 0.89f)
            {
                targetValue = 1.0f;
            }

            if (targetValue != loadingSlider.value)
            {
                //插值运算  
                loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
                if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
                {
                    loadingSlider.value = targetValue;
                }
                //loadingSlider.value = targetValue;
            }
            loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";
        }
    }
}
