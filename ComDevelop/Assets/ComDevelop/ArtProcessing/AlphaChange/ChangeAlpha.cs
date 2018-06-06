using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComDevelop.ART;

public class ChangeAlpha : MonoBehaviour
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

    public float speedChange;
    public float fadePercent;

    // Update is called once per frame
    void Update()
    {
        if (alphaChangeToTransBool)
        {
            if (GameObjFade() == fadePercent)
            {
                alphaChangeToTransBool = false;
                if (fadePercent == 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (alphaChangeToBackBool)
        {
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


    public void FadeGameObjInit()
    {
        if (alphaChangeToTransBool == false)
        {
            alphaChangeToTransBool = false;
            alphaChangeToBackBool = false;

            alphaNum = 1;
            mRender = gameObject.GetComponentsInChildren<Renderer>();
            tempColor = new Color[mRender.Length];
            for (int i = 0; i < mRender.Length; ++i)
            {
                tempColor[i] = mRender[i].material.color;
                MaterialRenderingMode.SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);
                alphaNum = tempColor[i].a;
                mRender[i].material.SetInt("_ZWrite", 1);

            }

            //运行完毕后，新的alphaNum为物体当前透明度
            alphaChangeToTransBool = true;
            alphaChangeToBackBool = false;
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


    public void ShowGameObjInit()
    {
        if (alphaChangeToBackBool == false)
        {
            alphaChangeToTransBool = false;
            alphaChangeToBackBool = false;

            alphaNum = 0;
            mRender = gameObject.GetComponentsInChildren<Renderer>();
            tempColor = new Color[mRender.Length];

            for (int i = 0; i < mRender.Length; ++i)
            {
                tempColor[i] = mRender[i].material.color;
                MaterialRenderingMode.SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);
                alphaNum = tempColor[i].a;
                mRender[i].material.SetInt("_ZWrite", 1);

            }
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
            mRender[i].material.color = tempColor[i];
        }
        return alphaNum;
    }
}
