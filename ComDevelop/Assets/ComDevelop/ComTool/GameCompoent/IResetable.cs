using UnityEngine;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// 可重置接口：实现此接口的组件可以在对象池重用时重置状态
    /// Resetable Interface: Components implementing this interface can reset their state when reused from object pool
    /// </summary>
    public interface IResetable
    {
        /// <summary>
        /// 重置组件状态
        /// Reset component state
        /// </summary>
        void OnReset();
    }
} 