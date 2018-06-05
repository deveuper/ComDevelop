using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComDevelop.ART;

public class ChangeAlpha : MonoBehaviour
{

    private Renderer[] mRender;
    private float alphaNum;
    private Color[] tempColor;
    private bool alphaChangeBool;
    private bool alphaShowChangeBool;

    public float speedChange;
    public float fadePercent;

    // Update is called once per frame
    void Update()
    {
        if (alphaChangeBool)
        {
            if (GameObjFade() == fadePercent)
            {
                alphaChangeBool = false;
                if (fadePercent == 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (alphaShowChangeBool)
        {
            if (GameObjShow() == fadePercent)
            {
                alphaShowChangeBool = false;
                if (fadePercent == 1)
                {
                    gameObject.SetActive(true);
                }
            }
        }
    }



    public void FadeGameObjInit()
    {
        if (alphaChangeBool == false)
        {
            alphaNum = 1;
            mRender = gameObject.GetComponentsInChildren<Renderer>();
            tempColor = new Color[mRender.Length];
            for (int i = 0; i < mRender.Length; ++i)
            {
                tempColor[i] = mRender[i].material.color;
                SetMaterialRenderingMode(mRender[i].material, RenderingMode.Fade);
                alphaNum = tempColor[i].a;
                mRender[i].material.SetInt("_ZWrite", 1);

            }
            alphaChangeBool = true;

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
        if (alphaShowChangeBool == false)
        {
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
            alphaShowChangeBool = true;

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

    public static void SetMaterialRenderingMode(Material material, RenderingMode renderingMode)
    {
        switch (renderingMode)
        {
            case RenderingMode.Opaque:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case RenderingMode.Cutout:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case RenderingMode.Fade:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 1);// material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case RenderingMode.Transparent:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }
}
