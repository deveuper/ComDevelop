using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlphaTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject changeObject;
    private void OnGUI()
    {
        if (GUILayout.Button("透明"))
        {
            changeObject.GetComponent<Renderer>().material.SetInt("_ZWrite", 1);
        }

        if (GUILayout.Button("返回"))
        {
            changeObject.GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
        }
    }
}
