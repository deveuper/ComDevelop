using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComDevelop.ART;
namespace ComDevelop.ART
{

    public class ShowAlpha : MonoBehaviour
    {
        public Renderer[] mRender;

        [Range(0, 1)]
        public float alphaNum;
        Color[] tempColor;

        // Use this for initialization
        void Start()
        {
            mRender = GetComponentsInChildren<Renderer>();
            tempColor = new Color[mRender.Length];
            for (int i = 0; i < mRender.Length; ++i)
            {
                tempColor[i] = mRender[i].material.color;

                MaterialRenderingMode.SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);

            }
            alphaNum = tempColor[0].a;
            Debug.Log("mRender " + mRender.Length);
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < mRender.Length; ++i)
            {
                mRender[i].material.SetInt("_ZWrite", 1);
                //tempColor[i].a = alphaNum;
                //mRender[i].material.color = tempColor[i];
            }
        }

    }
}