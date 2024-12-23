using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace ComDevelop.LocaScene
{
    /// <summary>
    /// 场景加载管理器
    /// </summary>
    public class SceneLoadManager : MonoBehaviour
    {
        private static SceneLoadManager instance;

        public static SceneLoadManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("SceneLoadManager");
                    instance = go.AddComponent<SceneLoadManager>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="targetSceneName">目标场景名称</param>
        /// <param name="loadType">加载方式</param>
        public void LoadScene(string targetSceneName, LoadSceneType loadType = LoadSceneType.UnityLoad)
        {
            GlobalLoad.nextSceneName = targetSceneName;

            // 根据不同的加载方式加载对应的加载场景
            string loadingSceneName = "";
            switch (loadType)
            {
                case LoadSceneType.UnityLoad:
                    SceneManager.LoadScene(targetSceneName);
                    break;
                case LoadSceneType.SilderLoad:
                    loadingSceneName = "LoadingScene_Silder";
                    break;
                case LoadSceneType.CanvasLoad:
                    loadingSceneName = "LoadingScene_Canvas";
                    break;
                case LoadSceneType.SilderWithCanvasLoad:
                    loadingSceneName = "LoadingScene_SliderAndCanvas";
                    break;
            }
      // 先同步加载加载场景，然后在加载场景中使用LoadingSceneSystem来异步加载目标场景
            if(!string.IsNullOrEmpty(loadingSceneName))
            {
                SceneManager.LoadScene(loadingSceneName);
            }
        }

        /// <summary>
        /// 加载下一个场景
        /// </summary>
        /// <param name="loadType">加载方式</param>
        public void LoadNextScene(LoadSceneType loadType = LoadSceneType.UnityLoad)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(
                    SceneUtility.GetScenePathByBuildIndex(nextSceneIndex));
                LoadScene(nextSceneName, loadType);
            }
            else
            {
                Debug.LogWarning("No next scene available!");
            }
        }
    }
} 