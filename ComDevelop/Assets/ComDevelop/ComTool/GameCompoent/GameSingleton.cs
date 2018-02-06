using System;
using System.Collections;
using UnityEngine;
namespace ComDevelop.ComTool
{
    /// <summary>
    /// Create a Singleton <T> Gameobject only one in current hierachy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameSingleton<T> : MonoBehaviour where T : GameSingleton<T>
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)//Determine Generate Object
                {
                    instance = FindObjectOfType(typeof(T)) as T;//Find T type In hierarchy Panel
                    if (instance == null)
                    {
                        instance = new GameObject("_" + typeof(T).Name).AddComponent<T>();//Intance a GameObject with T type Object
                        DontDestroyOnLoad(instance);
                    }
                    if (instance == null)
                    {
                        Debug.Log("Faild to create instance of " + typeof(T).FullName + ".");
                    }
                }
                return instance;
            }
        }
        private void OnApplicationQuit()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        protected virtual void Init() { }
    }
}

