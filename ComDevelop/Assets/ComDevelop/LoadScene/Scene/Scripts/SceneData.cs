using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ComDevelop.LocaScene
{
    /// <summary>
    /// 场景数据
    /// </summary>
    [Serializable]
    public class SceneData
    {
        public Slider loadingSlider;

        public Text loadingText;
        //差值计算
        public float loadingSpeed = 10;
        //黑屏时间
        public float internalTime = 0.2f;
        public GameObject CameraShow;
        /// <summary>
        /// 加载场景进度值
        /// </summary>
        [HideInInspector]
        public float targetValue;
    }
}
