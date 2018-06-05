using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClearAllData : MonoBehaviour
{
    public float timeNow;

    public Text mText;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        this.timeNow = Time.time + 5f;
       
    }

    private void Update()
    {
        if (Time.time > this.timeNow)
        {
            
        }
    }
}

