using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComDevelop.ComTool
{
    /// <summary>
    /// Transform工具类：提供Transform相关的常用操作方法
    /// Transform Helper: Provides common Transform operation methods
    /// </summary>
    public static class TransformHelper
    {
        /// <summary>
        /// 递归查找指定名称的子物体
        /// Find child transform recursively by name
        /// </summary>
        /// <param name="transParent">父物体 | Parent transform</param>
        /// <param name="findName">查找的名称 | Name to find</param>
        /// <returns>找到的Transform，未找到返回null | Found transform or null</returns>
        public static Transform FindChild(Transform transParent, string findName)
        {
            if (transParent == null || string.IsNullOrEmpty(findName))
                return null;

            // 先查找直接子物体
            Transform transChild = transParent.Find(findName);
            if (transChild != null)
            {
                return transChild;
            }

            // 递归查找子物体
            for (int i = 0; i < transParent.childCount; i++)
            {
                transChild = FindChild(transParent.GetChild(i), findName);
                if (transChild != null)
                {
                    return transChild;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取世界空间位置（非局部坐标）
        /// Get position in world space (not local position)
        /// </summary>
        /// <param name="transLocal">目标Transform | Target transform</param>
        /// <param name="result">结果位置 | Result position</param>
        /// <returns>世界空间位置 | World position</returns>
        public static Vector3 GetWorldPosition(Transform transLocal, ref Vector3 result)
        {
            if (transLocal == null)
                return result;

            if (transLocal.parent != null && transLocal.parent.parent != null)
            {
                result += transLocal.parent.localPosition;
                GetWorldPosition(transLocal.parent, ref result);
            }
            if (transLocal.parent != null && transLocal.parent.parent == null)
            {
                return result;
            }
            return result;
        }

        /// <summary>
        /// 查找多个指定名称的子物体
        /// Find multiple child transforms by names
        /// 注意：名称在列表中必须唯一 | Note: names must be unique in the list
        /// </summary>
        /// <param name="transParent">父物体 | Parent transform</param>
        /// <param name="findNames">要查找的名称数组 | Names to find</param>
        /// <returns>找到的Transform列表 | List of found transforms</returns>
        public static List<Transform> FindAllChild(Transform transParent, string[] findNames)
        {
            if (transParent == null || findNames == null)
                return new List<Transform>();

            List<Transform> list = new List<Transform>();
            for (int i = 0; i < findNames.Length; i++)
            {
                Transform child = FindChild(transParent, findNames[i]);
                list.Add(child); // 即使未找到(null)也添加到列表中保持索引对应
            }
            return list;
        }

        /// <summary>
        /// 获取或添加组件
        /// Get or add component
        /// </summary>
        public static T GetOrAddComponent<T>(GameObject go) where T : Component
        {
            if (go == null) return null;
            
            T component = go.GetComponent<T>();
            if (component == null)
            {
                component = go.AddComponent<T>();
            }
            return component;
        }

        /// <summary>
        /// 获取或添加组件
        /// Get or add component
        /// </summary>
        public static T GetOrAddComponent<T>(Transform transform) where T : Component
        {
            if (transform == null) return null;
            return GetOrAddComponent<T>(transform.gameObject);
        }
    }
}