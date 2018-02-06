using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ComDevelop.ComTool;
using System;
namespace ComDevelop.LocaScene
{
    /// <summary>
    /// 进度条切换场景
    /// </summary>

    public class LoadSceneSilder : BaseLoadScene
    {
        public override IEnumerator LoadScene()
        {
            return base.LoadScene();
            if (loadingSlider == null)
            {
                loadingSlider = GameObject.FindObjectOfType<Slider>();
                loadingSlider.value = 0.0f;
            }
        }
        public override void Loading()
        {
            targetValue = operation.progress;

            if (operation.progress >= 0.9f)
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

            if ((int)(loadingSlider.value * 100) == 100)
            {
                //允许异步加载完毕后自动切换场景  
                operation.allowSceneActivation = true;
                //销毁所有Gameobject
                for (int i = 0; i < DoNotDestroyOnLoad_Com.FristNotDestoryObjList.Count; i++)
                {
                    GameObject.Destroy(DoNotDestroyOnLoad_Com.FristNotDestoryObjList[i]);
                }
            }
        }
    }
}
