using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 使用滑动条，更改透明
/// 修改Renderer Mode为Transparent或者Fade
/// </summary>
public class TestAlphaController : MonoBehaviour {

    [Header("Shader Rendering Mode : Fade/Transparent")]
    public Slider mySlider;
    public Color theColor;
	
    // Use this for initialization
	void Start () {
        Color myStartColor = gameObject.GetComponent<Renderer>().material.color;
		theColor  = new Color(myStartColor.r, myStartColor.g, myStartColor.b, myStartColor.a);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", theColor);
	}

    public void MaterialAlpha()
    {
        theColor.a = mySlider.value;
    }
}
