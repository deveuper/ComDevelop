using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ComDevelop.ComTool
{
    /// <summary>
    /// Help using transform information
    /// </summary>
    public class TransformHelper
    {
        /// <summary>
        /// FindChild the first transform object by name
        /// </summary>
        /// <param name="transParent">the object you want to find in </param>
        /// <param name="findName">name</param>
        /// <returns></returns>
        public static Transform FindChild(Transform transParent, string findName)
        {
            Transform transChild = transParent.Find(findName);
            if (transChild != null)
            {
                return transChild;
            }
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
        /// Find the position in world space(not local position):opposite position
        /// </summary>
        /// <param name="transLocal">input trans</param>
        /// <param name="result">input trans position</param>
        /// <returns></returns>
        public static Vector3 GetWorldPosition(Transform transLocal, ref Vector3 result)
        {
            if (transLocal.parent != null && transLocal.parent.parent != null)
            {
                result += transLocal.parent.localPosition;
                GetWorldPosition(transLocal.parent,ref result);
            }
            if (transLocal.parent != null && transLocal.parent.parent == null)
            {
                return result;
            }
            return result;
        }


        /// <summary>
        /// FindChild transform objects by name : 
        /// Just can use when the name is single on nameList
        /// </summary>
        /// <param name="transParent"></param>
        /// <param name="findNames"></param>
        /// <returns></returns>
        public static List<Transform> FindAllChild(Transform transParent, string[] findNames)
        {
            List<Transform> list = new List<Transform>();
            for (int i = 0; i < findNames.Length; i++)
            {
                list.Add(FindChild(transParent, findNames[i]));
            }
            return list;
        }
    }
}