using ComDevelop.LocaScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ComDevelop.LocaScene
{
    public class ButtonLoad : MonoBehaviour
    {
        public string SceneName;

        //异步加载新场景:进度条
        public void LoadNewSceneSlider()
        {
            //保存需要加载的目标场景  
            GlobalLoad.nextSceneName = SceneName;
            SceneManager.LoadScene("LoadingScene_Silder");
        }
        //异步加载新场景:明暗变化
        public void LoadNewSceneCanvas()
        {
            //保存需要加载的目标场景  
            GlobalLoad.nextSceneName = SceneName;
            SceneManager.LoadScene("LoadingScene_Canvas");
        }
        //加载场景：Unity自带加载
        public void LoadingNewSceneUnity()
        {
            GlobalLoad.nextSceneName = SceneName;
            SceneManager.LoadScene(SceneName);
        }
        public void LoadingNewScene_SliderAndCanvas()
        {
            GlobalLoad.nextSceneName = SceneName;
            SceneManager.LoadScene("LoadingScene_SliderAndCanvas");
        }
    }
}