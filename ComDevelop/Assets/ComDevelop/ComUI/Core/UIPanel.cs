using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace ComDevelop.ComUI
{
    /// <summary>
    /// UI面板基类，所有UI面板都应继承此类
    /// </summary>
    public abstract class UIPanel : MonoBehaviour
    {
        [Header("Panel Settings")]
        public bool keepAliveOnLoad = false;  // 是否在加载时保持存活
        
        protected virtual void Awake()
        {
            if(keepAliveOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// 显示面板
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// 隐藏面板
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// 初始化面板
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// 刷新面板
        /// </summary>
        public virtual void Refresh() { }
    }
}