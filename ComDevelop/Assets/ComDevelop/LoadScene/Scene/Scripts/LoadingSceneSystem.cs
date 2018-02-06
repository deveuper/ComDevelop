using UnityEngine;
using UnityEngine.SceneManagement;

namespace ComDevelop.LocaScene
{
    public class GlobalLoad
    {
        public static string nextSceneName;
    }
    //加载场景模式
    public enum LoadSceneType
    {
        UnityLoad,//Unity自带的加载
        SilderLoad,//进度条加载
        CanvasLoad,//画布明暗加载
        SilderWithCanvasLoad//先明暗，在进度条进行加载（适用于大场景）
    }
    public class LoadingSceneSystem : MonoBehaviour
    {
        public LoadSceneType LoadType = LoadSceneType.UnityLoad;

        private BaseLoadScene BaseLoad;

        public SceneData sceneData;
        // Use this for initialization  
        void Start()
        {
            //选择加载场景的模式
            switch (LoadType)
            {
                case LoadSceneType.UnityLoad:
                    BaseLoad = new UnityLoadScene();
                    break;
                case LoadSceneType.SilderLoad:
                    BaseLoad = new LoadSceneSilder();
                    break;
                case LoadSceneType.CanvasLoad:
                    BaseLoad = new LoadSceneCanvas();
                    break;
                case LoadSceneType.SilderWithCanvasLoad:
                    BaseLoad = new SilderWithCanvasLoad();
                    break;
            }
            GetSceneData();
            StartCoroutine(BaseLoad.LoadScene());
        }
        private void GetSceneData()
        {
            BaseLoad.loadingSlider = sceneData.loadingSlider;
            BaseLoad.loadingText = sceneData.loadingText;
            BaseLoad.loadingSpeed = sceneData.loadingSpeed;
            BaseLoad.internalTime = sceneData.internalTime;
            BaseLoad.CameraShow = sceneData.CameraShow;
            BaseLoad.targetValue = sceneData.targetValue;
        }

        // Update is called once per frame  
        void Update()
        {
            BaseLoad.Loading();
        }
    }

}