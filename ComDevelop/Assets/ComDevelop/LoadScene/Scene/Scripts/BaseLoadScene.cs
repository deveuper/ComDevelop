using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ComDevelop.LocaScene
{
    [Serializable]
    public class BaseLoadScene
    {
        public Slider loadingSlider;

        public Text loadingText;
        //差值计算
        public float loadingSpeed = 10;
        public float loadingCanvasSpeed = 10;
        //黑屏时间
        public float internalTime = 0.2f;
        //黑屏时的摄像机：加载后观看:暗-->明,setactive
        public GameObject CameraShow;
        /// <summary>
        /// 加载场景进度值
        /// </summary>
        [HideInInspector]
        public float targetValue;

        [HideInInspector]
        public AsyncOperation operation;

        /// <summary>
        /// 阻止当加载完成自动切换
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator LoadScene()
        {
            operation = SceneManager.LoadSceneAsync(GlobalLoad.nextSceneName);
            //阻止当加载完成自动切换  
            operation.allowSceneActivation = false;

            yield return operation;

        }
        /// <summary>
        /// 加载-加载场景
        /// </summary>
        public virtual void Loading()
        {

        }
    }
}
