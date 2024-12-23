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
        private bool isReadyToChange = false;

        private void InitializeSlider()
        {
            if (!loadingSlider)
            {
                loadingSlider = GameObject.FindObjectOfType<Slider>();
                if(loadingSlider)
                {
                    loadingSlider.value = 0f;
                }
                else
                {
                    Debug.LogError("Loading slider not found!");
                }
            }
        }

        protected override void UpdateUI()
        {
            if(loadingSlider && targetValue != loadingSlider.value)
            {
                //插值运算  
                float displayValue = targetValue;
                // 当实际加载达到90%时，显示值渐进到100%
                if(operation.progress >= 0.9f)
                {
                    displayValue = 1.0f;
                    isReadyToChange = true;
                }

                loadingSlider.value = Mathf.Lerp(loadingSlider.value, displayValue, Time.deltaTime * loadingSpeed);
                
                // 确保最后一定会到达目标值
                if (isReadyToChange && displayValue - loadingSlider.value < 0.01f)
                {
                    loadingSlider.value = 1.0f;
                }
            }

            if(loadingText)
            {
                // 显示进度文本
                loadingText.text = string.Format("{0}%", (int)(loadingSlider.value * 100));
            }
        }

        public override void Loading()
        {
            InitializeSlider();
            UpdateLoadingProgress();

            // 当实际加载完成且进度条显示100%时切换场景
            if (operation.progress >= 0.9f && loadingSlider.value >= 0.999f)
            {
                OnLoadComplete();
                operation.allowSceneActivation = true;
            }
        }
    }
}
