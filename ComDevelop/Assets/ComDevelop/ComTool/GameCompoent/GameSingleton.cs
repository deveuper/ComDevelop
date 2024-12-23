using UnityEngine;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 游戏单例基类：确保场景中只有一个实例存在
    /// Game Singleton Base: Ensure only one instance exists in scene
    /// </summary>
    public class GameSingleton<T> : MonoBehaviour where T : GameSingleton<T>
    {
        // 静态实例 | Static instance
        private static T s_Instance = null;
        
        // 是否已经销毁 | Whether destroyed
        private static bool s_ApplicationIsQuitting = false;

        /// <summary>
        /// 获取单例实例 | Get singleton instance
        /// </summary>
        public static T Instance
        {
            get
            {
                // 如果程序正在退出，不再创建实例 | Don't create instance if application is quitting
                if (s_ApplicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance of " + typeof(T).Name + " already destroyed due to application quit.");
                    return null;
                }

                // 如果实例不存在，尝试查找或创建 | Try to find or create instance if not exists
                if (!s_Instance)
                {
                    // 查找场景中是否存在实例 | Find instance in scene
                    s_Instance = FindObjectOfType(typeof(T)) as T;

                    // 如果场景中不存在，创建新实例 | Create new instance if not found
                    if (!s_Instance)
                    {
                        // 创建持久化游戏物体 | Create persistent game object
                        GameObject go = new GameObject("_" + typeof(T).Name);
                        s_Instance = go.AddComponent<T>();
                        DontDestroyOnLoad(go);

                        Debug.Log("[Singleton] Created new instance of " + typeof(T).Name);
                    }
                }

                return s_Instance;
            }
        }

        /// <summary>
        /// 初始化方法，子类通过重写此方法来初始化
        /// Initialization method for child classes to override
        /// </summary>
        protected virtual void Init() { }

        protected virtual void Awake()
        {
            // 检查是否已存在实例 | Check if instance already exists
            if (!s_Instance)
            {
                s_Instance = this as T;
                DontDestroyOnLoad(gameObject);
                Init();
            }
            else if (s_Instance != this)
            {
                // 如果已存在其他实例，销毁当前对象 | Destroy current object if another instance exists
                string instanceName = s_Instance.gameObject.name;
                Destroy(gameObject);
                Debug.LogWarning("[Singleton] Trying to create another instance of " + typeof(T).Name + " while one already exists in '" + instanceName + "'.");
            }
        }

        protected virtual void OnDestroy()
        {
            if (s_Instance == this)
            {
                s_Instance = null;
            }
        }

        protected virtual void OnApplicationQuit()
        {
            s_ApplicationIsQuitting = true;
            s_Instance = null;
        }

        /// <summary>
        /// 检查实例是否存在 | Check if instance exists
        /// </summary>
        public static bool HasInstance
        {
            get { return s_Instance != null && !s_ApplicationIsQuitting; }
        }
    }
}

