using UnityEngine;

namespace ComDevelop.LocaScene
{
    /// <summary>
    /// Unity自带的场景加载方式
    /// </summary>
    [System.Serializable]
    public class UnityLoadScene : BaseLoadScene
    {
        public override void Loading()
        {
            // Unity自带加载方式直接允许场景激活
            if(operation != null && operation.progress >= 0.9f)
            {
                OnLoadComplete();
                operation.allowSceneActivation = true;
            }
        }
    }
}
