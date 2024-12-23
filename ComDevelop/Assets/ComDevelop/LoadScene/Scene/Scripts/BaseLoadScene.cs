using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using ComDevelop.ComTool;

namespace ComDevelop.LocaScene
{
    [Serializable]
    public abstract class BaseLoadScene
    {
        [Header("UI References")]
        public Slider loadingSlider;
        public Text loadingText;
        
        [Header("Loading Settings")]
        public float loadingSpeed = 10f;
        public float internalTime = 0.2f;
        //黑屏时的摄像机：加载后观看:暗-->明,setactive
        [Header("Scene References")] 
        public GameObject CameraShow;

        protected AsyncOperation operation;
        /// <summary>
        /// 加载场景进度值
        /// </summary>
        public float targetValue;
        
        private const float LOAD_COMPLETE_VALUE = 0.9f;

        /// <summary>
        /// 加载场景,异步,阻止加载完自动切换
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator LoadScene()
        {
            // 预加载场景但不激活
            operation = SceneManager.LoadSceneAsync(GlobalLoad.nextSceneName);
            if(operation == null)
            {
                Debug.LogError(string.Format("Failed to load scene: {0}", GlobalLoad.nextSceneName));
                yield break;
            }

            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                UpdateLoadingProgress();
                yield return null;
            }
        }

        protected virtual void UpdateLoadingProgress()
        {
            targetValue = operation.progress;
            
            if (operation.progress >= LOAD_COMPLETE_VALUE)
            {
                targetValue = 1.0f;
            }

            UpdateUI();
        }

        protected virtual void UpdateUI()
        {
            if(loadingSlider)
            {
                loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
            }

            if(loadingText)
            {
                loadingText.text = string.Format("{0}%", (int)(loadingSlider.value * 100));
            }
        }

        protected virtual void OnLoadComplete()
        {
            if(DoNotDestroyOnLoad_Com.FristNotDestoryObjList != null)
            {
                foreach(var obj in DoNotDestroyOnLoad_Com.FristNotDestoryObjList)
                {
                    if(obj)
                    {
                        GameObject.Destroy(obj);
                    }
                }
            }
        }

        public abstract void Loading();
    }
}
