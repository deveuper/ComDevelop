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
        /// <summary>
        /// 控制：变为透明
        /// </summary>
        private bool alphaChangeToTransBool;
        /// <summary>
        /// 控制：变回与原状态
        /// </summary>
        private bool alphaChangeToBackBool;

        private float speedChange;

        public float fadePercent;

        // Update is called once per frame
        void Update()
        {
            if (alphaChangeToTransBool)
            {
                if (GameObjFade() == fadePercent)
                {
                    if (fadePercent == 0)
                    {
                        gameObject.GetComponent<Renderer>().enabled = false;
                    }
                    alphaChangeToTransBool = false;
                }
            }
            if (alphaChangeToBackBool)
            {
                gameObject.GetComponent<Renderer>().enabled = true;

                if (GameObjShow() == fadePercent)
                {
                    alphaChangeToBackBool = false;

                    if (fadePercent == 1)
                    {
                        gameObject.SetActive(true);
                    }
                }
            }
        }
        /// <summary>
        /// 开始隐藏物体
        /// </summary>
        /// <param name="obj">需要隐藏的物体：必须有MeshRenderer</param>
        /// <param name="percnet">0~1之间需要改变的透明度</param>
        /// <param name="speed">速度，建议小数</param>
        public void FadeGameObjInit(GameObject obj, float percnet, float speed)
        {
            if (alphaChangeToTransBool == false)
            {
                alphaNum = 1;
                mRender = obj.GetComponentsInChildren<Renderer>();
                tempColor = new Color[mRender.Length];
                for (int i = 0; i < mRender.Length; ++i)
                {
                    tempColor[i] = mRender[i].material.color;
                    //MaterialRenderingMode.SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);

                    mRender[i].material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    mRender[i].material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    mRender[i].material.SetInt("_ZWrite", 0);
                    mRender[i].material.DisableKeyword("_ALPHATEST_ON");
                    mRender[i].material.EnableKeyword("_ALPHABLEND_ON");
                    mRender[i].material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    mRender[i].material.renderQueue = 3000;



                    //tempColor[i].a = alphaNum;
                    alphaNum = tempColor[i].a;
                    mRender[i].material.SetInt("_ZWrite", 1);
                }
                alphaChangeToTransBool = true;
                alphaChangeToBackBool = false;
                fadePercent = percnet;
                speedChange = speed;
            }
        }

        private float GameObjFade() //手动lerp---此方式，可以真正的得到 a==b的值
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
        /// <summary>
        /// 开始显示物体
        /// </summary>
        /// <param name="obj">需要显示的物体：必须有MeshRnederer</param>
        /// <param name="percnet"></param>
        /// <param name="speed"></param>
        public void ShowGameObjInit(GameObject obj, float percnet, float speed)
        {
            if (alphaChangeToBackBool == false)
            {
                alphaChangeToTransBool = false;
                alphaChangeToBackBool = false;

                alphaNum = 0;
                mRender = obj.GetComponentsInChildren<Renderer>();
                tempColor = new Color[mRender.Length];

                for (int i = 0; i < mRender.Length; ++i)
                {
                    tempColor[i] = mRender[i].material.color;
                    MaterialRenderingMode.SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);
                    alphaNum = tempColor[i].a;
                    mRender[i].material.SetInt("_ZWrite", 1);

                }
                fadePercent = percnet;
                speedChange = speed;

                alphaChangeToBackBool = true;
                alphaChangeToTransBool = false;
            }
        }

        float GameObjShow()
        {
            alphaNum += Time.deltaTime * speedChange;
            alphaNum = Mathf.Min(alphaNum, fadePercent);
            for (int i = 0; i < mRender.Length; ++i)
            {
                mRender[i].material.SetInt("_ZWrite", 1);
                tempColor[i].a = alphaNum;
                //Debug.Log( "当前的::" + alphaNum);
                mRender[i].material.color = tempColor[i];
            }
            return alphaNum;
        }

    }
}