using UnityEngine;
using UnityEngine.UI;

namespace ComDevelop.LocaScene
{
    /// <summary>
    /// 场景加载示例
    /// </summary>
    public class SceneLoadExample : MonoBehaviour
    {
        [Header("Scene Settings")]
        public string targetSceneName = "SceneB";
        
        [Header("UI References")]
        public Button sliderLoadButton;
        public Button canvasLoadButton;
        public Button directLoadButton;
        public Button mixedLoadButton;

        private void Start()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            if(sliderLoadButton)
                sliderLoadButton.onClick.AddListener(() => LoadWithType(LoadSceneType.SilderLoad));
            
            if(canvasLoadButton)
                canvasLoadButton.onClick.AddListener(() => LoadWithType(LoadSceneType.CanvasLoad));
            
            if(directLoadButton)
                directLoadButton.onClick.AddListener(() => LoadWithType(LoadSceneType.UnityLoad));
            
            if(mixedLoadButton)
                mixedLoadButton.onClick.AddListener(() => LoadWithType(LoadSceneType.SilderWithCanvasLoad));
        }

        private void LoadWithType(LoadSceneType loadType)
        {
            SceneLoadManager.Instance.LoadScene(targetSceneName, loadType);
        }

        // 也可以直接在其他脚本中这样使用:
        private void LoadSceneExample()
        {
            // 加载指定场景
            SceneLoadManager.Instance.LoadScene("SceneB", LoadSceneType.SilderLoad);
            
            // 或加载下一个场景
            SceneLoadManager.Instance.LoadNextScene(LoadSceneType.CanvasLoad);//不使用
        }
    }
} 