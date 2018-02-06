using System.Collections.Generic;
using UnityEngine;
namespace ComDevelop.ComTool
{
    public class DoNotDestroyOnLoad_Com : MonoBehaviour
    {
        public static List<string> DoNotDesNamelist = new List<string>();

        private void Awake()
        {
            if (DoNotDesNamelist.Contains(this.name))
            {
                GameObject.Destroy(this.gameObject);
            }
        }
        public void DestroySelfObject()
        {
           
        }
        void Start()
        {
            if (DoNotDestoryList != null)
            {
                FristNotDestoryObjList = new List<GameObject>(DoNotDestoryList.Count);
                for (int i = 0; i < DoNotDestoryList.Count; i++)
                {
                    FristNotDestoryObjList.Add(DoNotDestoryList[i]);
                    DontDestroyOnLoad(DoNotDestoryList[i]);
                }
            }

            DontDestroyOnLoad(this.gameObject);
            DoNotDesNamelist.Add(this.name);
        }
        public List<GameObject> DoNotDestoryList;

        public static List<GameObject> FristNotDestoryObjList;
    }
}