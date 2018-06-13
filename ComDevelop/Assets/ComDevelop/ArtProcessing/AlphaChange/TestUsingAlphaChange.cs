using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using ComDevelop.ART;

public class TestUsingAlphaChange : MonoBehaviour
{
    //按钮
    public Button buttonAlpha;
    public Button buttonAlphaBack;
    //需要透明的物体
    [Header("需要透明的物体")]
    public GameObject modelAlpha;
    [Header("渐变透明的速度:1-100")]
    public float AlphaSpeed;
    [Header("透明的比率：小数")]
    public float AlphaValue = 0.5f;

    public Text textUI;

    // Use this for initialization
    void Start()
    {
        textUI.text = "";
        buttonAlpha.onClick.AddListener(StartAlpha);
        buttonAlphaBack.onClick.AddListener(StartAlphaBack);
    }

    //开始透明
    private void StartAlpha()
    {
        AlphaChangePercent acPercent = modelAlpha.GetComponent<AlphaChangePercent>();
        if (acPercent == null)
        {
            acPercent = modelAlpha.AddComponent<AlphaChangePercent>();
        }
        acPercent.FadeGameObjInit(modelAlpha, AlphaValue, AlphaSpeed * 0.01f);
    }
    //从透明返回
    private void StartAlphaBack()
    {
        AlphaChangePercent acPercent = modelAlpha.GetComponent<AlphaChangePercent>();
        if (acPercent == null)
        {
            acPercent = modelAlpha.AddComponent<AlphaChangePercent>();
        }
        acPercent.ShowGameObjInit(modelAlpha, 1f, AlphaSpeed * 0.01f);
    }
    private void Update()
    {
        textUI.text = modelAlpha.GetComponent<Renderer>().material.color.a.ToString();
    }


}
