using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using ComDevelop.ComTool;

namespace ComDevelop.ComUI
{
    /// <summary>
    /// UI面板类型
    /// </summary>
    public enum Panel
    {
        Main,
        InGame,
        Pause,
        Fade,
        None
    }

    /// <summary>
    /// UI管理器：控制所有UI面板的显示、隐藏和切换
    /// </summary>
    public class UIManager : GameSingleton<UIManager>
    {
        [Header("Panel References")]
        [SerializeField] private MainMenuPanel mainMenuPanel;
        [SerializeField] private InGamePanel inGamePanel;
        [SerializeField] private PausePanel pausePanel;
        [SerializeField] public FadePanel fadePanel;

        [Header("Fade Settings")]
        [SerializeField] private FadePanel.FadeType defaultFadeType = FadePanel.FadeType.FadeOutIn;  // 在UIManager中设置默认渐变类型
        [SerializeField] private float defaultWaitTime = 0.5f;  // 默认等待时间

        private Dictionary<Panel, UIPanel> panelDictionary;
        public Action ActionFade;

        protected override void Init()
        {
            base.Init();
            InitializePanels();
            
            // 如果有FadePanel，设置其默认值
            if(fadePanel != null)
            {
                fadePanel.defaultFadeType = defaultFadeType;
                fadePanel.InternalWaitTime = defaultWaitTime;
            }
        }

        private void Start()
        {
            // 使用UIManager中设置的默认渐变类型
            Fade(defaultFadeType, ActionFade);
            TransformHelper.FindChild(transform,"");
        }

        /// <summary>
        /// 初始化所有面板
        /// </summary>
        private void InitializePanels()
        {
            panelDictionary = new Dictionary<Panel, UIPanel>();
            
            if(mainMenuPanel != null) panelDictionary.Add(Panel.Main, mainMenuPanel);
            if(inGamePanel != null) panelDictionary.Add(Panel.InGame, inGamePanel);
            if(pausePanel != null) panelDictionary.Add(Panel.Pause, pausePanel);
            if(fadePanel != null) panelDictionary.Add(Panel.Fade, fadePanel);

            // 初始化所有面板
            foreach(var panel in panelDictionary.Values)
            {
                if(panel != null)
                {
                    panel.Initialize();
                }
            }
        }

        /// <summary>
        /// 设置指定面板的激活状态
        /// </summary>
        public void SetPanelActive(Panel panelType)
        {
            foreach(var pair in panelDictionary)
            {
                if(pair.Value != null)
                {
                    if(pair.Key == panelType)
                    {
                        pair.Value.Show();
                    }
                    else
                    {
                        pair.Value.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// 使用指定类型执行渐变效果
        /// </summary>
        /// <param name="fadeType">渐变类型</param>
        /// <param name="finalCallback">完成回调</param>
        /// <param name="waitTime">等待时间,默认使用panel中设定的时间</param>
        public void Fade(FadePanel.FadeType fadeType, Action finalCallback = null, float waitTime = -1)
        {
            if(fadePanel != null)
            {
                float actualWaitTime = waitTime < 0 ? fadePanel.InternalWaitTime : waitTime;
                StartCoroutine(fadePanel.Fade(fadeType, actualWaitTime, finalCallback));
            }
            else
            {
                Debug.LogWarning("FadePanel is not assigned!");
            }
        }

        /// <summary>
        /// 使用默认渐变类型执行渐变（保持向后兼容）
        /// </summary>
        public void Fade(Action finalCallback, params Action[] callback)
        {
            if(fadePanel != null)
            {
                StartCoroutine(fadePanel.Fade(finalCallback, callback));
            }
            else
            {
                Debug.LogWarning("FadePanel is not assigned!");
            }
        }

        /// <summary>
        /// 获取指定类型的面板
        /// </summary>
        public T GetPanel<T>(Panel panelType) where T : UIPanel
        {
            UIPanel panel;
            if(panelDictionary.TryGetValue(panelType, out panel))
            {
                return panel as T;
            }
            return null;
        }
    }
}
