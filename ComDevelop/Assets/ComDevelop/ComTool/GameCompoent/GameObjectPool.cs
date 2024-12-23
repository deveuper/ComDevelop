using UnityEngine;
using System.Collections;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 游戏对象池：管理和重用游戏对象
    /// Game Object Pool: Manage and reuse game objects
    /// 
    /// 使用示例 | Usage Example:
    /// <code>
    /// public class BulletManager : MonoBehaviour 
    /// {
    ///     // 子弹预制体
    ///     public GameObject bulletPrefab;
    ///     
    ///     // 发射子弹
    ///     public void FireBullet(Vector3 position, Quaternion rotation)
    ///     {
    ///         // 从对象池获取或创建子弹
    ///         GameObject bullet = GameObjectPool.Instance.CreateObject(bulletPrefab, position, rotation);
    ///         
    ///         // 3秒后回收子弹
    ///         GameObjectPool.Instance.RecycleObject(bullet, 3f);
    ///     }
    /// }
    /// 
    /// // 子弹脚本示例
    /// public class Bullet : MonoBehaviour
    /// {
    ///     private float speed = 10f;
    ///     private float damage = 10f;
    ///     
    ///     // 当从对象池重用时会自动调用
    ///     private void OnObjectReset()
    ///     {
    ///         // 重置子弹状态
    ///         speed = 10f;
    ///         damage = 10f;
    ///     }
    ///     
    ///     private void OnCollisionEnter(Collision other)
    ///     {
    ///         // 碰撞后立即回收
    ///         GameObjectPool.Instance.RecycleObject(gameObject);
    ///     }
    /// }
    /// </code>
    /// 
    /// 主要功能 | Main Features:
    /// 1. 自动对象池管理，避免重复创建销毁
    /// 2. 支持延迟回收
    /// 3. 自动重置对象状态
    /// 4. 对象池自动扩容
    /// 
    /// 性能优化 | Performance Optimization:
    /// 1. 使用数组而非List，减少GC
    /// 2. 对象池按需扩容，避免内存浪费
    /// 3. 使用SendMessage替代接口，提高兼容性
    /// 
    /// 注意事项 | Notes:
    /// 1. 预制体需要挂载对应的脚本组件
    /// 2. OnObjectReset方法用于重置对象状态
    /// 3. 建议在对象不再使用时调用ClearAllPools清理内存
    /// </summary>
    public class GameObjectPool : GameSingleton<GameObjectPool>
    {
        // 对象池容器 | Object pool container
        private ObjectPoolContainer[] m_Pools;
        
        // 默认池大小 | Default pool size
        private const int DefaultPoolSize = 10;

        protected override void Init()
        {
            base.Init();
            m_Pools = new ObjectPoolContainer[0];
        }

        /// <summary>
        /// 创建对象 | Create object
        /// </summary>
        /// <param name="prefab">预制体 | Prefab</param>
        /// <param name="position">位置 | Position</param>
        /// <param name="rotation">旋转 | Rotation</param>
        public GameObject CreateObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (prefab == null)
            {
                Debug.LogError("[ObjectPool] Prefab is null!");
                return null;
            }

            // 查找或创建对应的对象池 | Find or create corresponding pool
            ObjectPoolContainer pool = GetPool(prefab);
            
            // 获取或创建对象 | Get or create object
            GameObject obj = pool.GetInactiveObject();
            if (obj == null)
            {
                obj = CreateNewObject(prefab, pool);
            }

            // 设置对象属性 | Set object properties
            SetupObject(obj, position, rotation);

            return obj;
        }

        /// <summary>
        /// 回收对象 | Recycle object
        /// </summary>
        public void RecycleObject(GameObject obj, float delay = 0f)
        {
            if (obj == null) return;

            if (delay > 0)
                StartCoroutine(RecycleCoroutine(obj, delay));
            else
                obj.SetActive(false);
        }

        /// <summary>
        /// 清理所有对象池 | Clear all pools
        /// </summary>
        public void ClearAllPools()
        {
            for (int i = 0; i < m_Pools.Length; i++)
            {
                if (m_Pools[i] != null)
                {
                    m_Pools[i].ClearPool();
                }
            }
            m_Pools = new ObjectPoolContainer[0];
        }

        // 内部方法 | Internal methods

        private ObjectPoolContainer GetPool(GameObject prefab)
        {
            // 查找现有池 | Find existing pool
            for (int i = 0; i < m_Pools.Length; i++)
            {
                if (m_Pools[i].Prefab == prefab)
                    return m_Pools[i];
            }

            // 创建新池 | Create new pool
            return CreateNewPool(prefab);
        }
        /// <summary>
        /// 创建新池 | Create new pool
        /// </summary>
        /// <param name="prefab"></param>
        /// <returns></returns>
        private ObjectPoolContainer CreateNewPool(GameObject prefab)
        {
            // 扩展数组 | Expand array
            ObjectPoolContainer[] newPools = new ObjectPoolContainer[m_Pools.Length + 1];
            for (int i = 0; i < m_Pools.Length; i++)
            {
                newPools[i] = m_Pools[i];
            }

            // 创建新池 | Create new pool
            ObjectPoolContainer newPool = new ObjectPoolContainer(prefab, DefaultPoolSize);
            newPools[newPools.Length - 1] = newPool;
            m_Pools = newPools;

            return newPool;
        }
        // 创建新对象 | Create new object
        private GameObject CreateNewObject(GameObject prefab, ObjectPoolContainer pool)
        {
            GameObject obj = Instantiate(prefab, transform, true);
            pool.AddObject(obj);
            return obj;
        }
        // 设置对象属性 | Set object properties
        private void SetupObject(GameObject obj, Vector3 position, Quaternion rotation)
        {
            // 重置变换 | Reset transform
            obj.transform.position = position;
            obj.transform.rotation = rotation;

            // 重置所有MonoBehaviour组件 | Reset all MonoBehaviour components
            MonoBehaviour[] components = obj.GetComponentsInChildren<MonoBehaviour>();
            for (int i = 0; i < components.Length; i++)
            {
                // 调用SendMessage以避免使用接口 | Use SendMessage to avoid interface
                components[i].SendMessage("OnObjectReset", SendMessageOptions.DontRequireReceiver);
            }

            obj.SetActive(true);
        }
        // 回收协程 | Recycle coroutine
        private IEnumerator RecycleCoroutine(GameObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            if (obj)
                obj.SetActive(false);
        }
    }

    /// <summary>
    /// 对象池容器：管理特定预制体的对象池
    /// Object Pool Container: Manage pool for specific prefab
    /// </summary>
    public class ObjectPoolContainer
    {
        public GameObject Prefab { get; private set; }
        private GameObject[] m_Objects;
        private int m_CurrentSize;
        // 构造函数 | Constructor
        public ObjectPoolContainer(GameObject prefab, int initialSize)
        {
            Prefab = prefab;
            m_Objects = new GameObject[initialSize];
            m_CurrentSize = 0;
        }
        /// <summary>
        /// 获取一个处于非激活状态的对象 | Get an object that is not active
        /// </summary>
        /// <returns></returns>
        public GameObject GetInactiveObject()
        {
            for (int i = 0; i < m_CurrentSize; i++)
            {
                if (m_Objects[i] != null && !m_Objects[i].activeInHierarchy)
                    return m_Objects[i];
            }
            return null;
        }
        /// <summary>
        /// 添加对象到池中 | Add object to pool
        /// </summary>
        /// <param name="obj"></param>
        public void AddObject(GameObject obj)
        {
            // 如果数组已满，扩容 | Expand array if full
            if (m_CurrentSize >= m_Objects.Length)
            {
                GameObject[] newArray = new GameObject[m_Objects.Length * 2];
                for (int i = 0; i < m_Objects.Length; i++)
                {
                    newArray[i] = m_Objects[i];
                }
                m_Objects = newArray;
            }

            m_Objects[m_CurrentSize++] = obj;
        }
        /// <summary>
        /// 清空对象池 | Clear pool
        /// </summary>
        public void ClearPool()
        {
            for (int i = 0; i < m_CurrentSize; i++)
            {
                if (m_Objects[i] != null)
                {
                    GameObject.Destroy(m_Objects[i]);
                }
            }
            m_Objects = new GameObject[0];
            m_CurrentSize = 0;
        }
    }
}