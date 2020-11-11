using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ComDevelop.ComUI
{
    /// <summary>
    /// Fade Panel :
    ///             From Transport to Dark and then form dark to transport:
    ///             On Game runtime ,just have only one fadepanel,and you can do thing like load scene in action
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class FadePanel : UIPanel
    {
        [HideInInspector]
        public CanvasGroup cGroup;
        public float fadeSpeed = 5;//control by loadScene script
        public float InternalWaitTime = 0.5f;
        [HideInInspector]
        public bool inProgress = true;
        public GameObject uiManager;//not using in this scripts
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(transform.parent);
            DontDestroyOnLoad(UIManager.Instance.gameObject);
            cGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator Fade(Action finalCallBack, params Action[] callback)
        {
            inProgress = true;
            while (cGroup.alpha < 0.95f)//From transport to black
            {
                cGroup.alpha = Mathf.Lerp(cGroup.alpha, 1, Time.deltaTime * fadeSpeed);
                yield return null;
            }
            //show UI form black to transport
            if (callback != null)//Do some thing when the panel is black
            {
                foreach (Action action in callback)
                {
                    action.Invoke();//Do you want to 
                }
            }
            //finalCallBack.Invoke();
            inProgress = false;
            cGroup.alpha = 1;
            yield return new WaitForSeconds(InternalWaitTime);//wait seconds when black

            while (cGroup.alpha > 0.05f)//From black to transport
            {
                cGroup.alpha = Mathf.Lerp(cGroup.alpha, 0, Time.deltaTime * fadeSpeed);
                yield return null;
            }
            cGroup.alpha = 0;

            Destroy(transform.parent.gameObject);
            Destroy(UIManager.Instance.gameObject);

            //inProgress = false;
        }
        
    }

}