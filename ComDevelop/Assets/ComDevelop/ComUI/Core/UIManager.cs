using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComDevelop.ComTool;
namespace ComDevelop.ComUI
{
    /// <summary>
    /// UIPanel for panel using
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
    /// To Control All Panel/UI item in Hierachy
    /// </summary>
    public class UIManager : GameSingleton<UIManager>
    {
        // Use this for initialization
        void Start()
        {
            Fade(actionFade,null);
            TransformHelper.FindChild(transform,"");
        }

        // Update is called once per frame
        void Update()
        {

        }
        [SerializeField]
        private MainMenuPanel mainMenuPanel;
        [SerializeField]
        private InGamePanel inGamePanel;
        [SerializeField]
        private PausePanel pausePanel;
        [SerializeField]
        public FadePanel fadePanel;


        public Action actionFade;
        /// <summary>
        /// active select panel
        /// </summary>
        /// <param name="panelType"></param>
        public void SetPanelActive(Panel panelType)
        {
            mainMenuPanel.gameObject.SetActive(panelType == Panel.Main);
            inGamePanel.gameObject.SetActive(panelType == Panel.InGame);
            pausePanel.gameObject.SetActive(panelType == Panel.Pause);
        }

        public void Fade(Action finalCallback, params Action[] callback)
        {
            StartCoroutine(fadePanel.Fade(finalCallback, callback));
        }
    }
}
