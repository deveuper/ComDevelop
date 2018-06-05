using ComDevelop.ART;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComDevelop.ART
{
    public class AlphaChangePercent : MonoBehaviour
    {

        private Renderer[] mRender;
        private float alphaNum;
        private Color[] tempColor;
        private bool alphaChangeBool;
        private float speedChange;

        public float fadePercent;

        // Update is called once per frame
        void Update()
        {
            if (alphaChangeBool)
            {
                if (GameObjFade() == fadePercent)
                {
                    if (fadePercent == 0)
                    {
                        gameObject.SetActive(false);
                    }
                    alphaChangeBool = false;
                }
            }
        }

        public void FadeGameObjInit(GameObject obj, float percnet, float speed)
        {
            if (alphaChangeBool == false)
            {
                alphaNum = 1;
                mRender = obj.GetComponentsInChildren<Renderer>();
                tempColor = new Color[mRender.Length];
                for (int i = 0; i < mRender.Length; ++i)
                {
                    tempColor[i] = mRender[i].material.color;
                    MaterialRenderingMode.SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);
                    tempColor[i].a = alphaNum;
                    mRender[i].material.SetInt("_ZWrite", 1);
                }
                alphaChangeBool = true;
                fadePercent = percnet;
                speedChange = speed;
            }
        }

        float GameObjFade()
        {
            alphaNum -= Time.deltaTime * speedChange;
            alphaNum = Mathf.Max(alphaNum, fadePercent);
            for (int i = 0; i < mRender.Length; ++i)
            {
                mRender[i].material.SetInt("_ZWrite", 1);
                tempColor[i].a = alphaNum;
                mRender[i].material.color = tempColor[i];
            }
            return alphaNum;
        }

    }
}