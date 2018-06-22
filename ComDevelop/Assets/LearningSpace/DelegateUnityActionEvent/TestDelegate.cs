using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{


    public delegate void MyDelegate(int args);

    public MyDelegate myDelegate;
    private void printNum(int args)
    {
        Debug.Log("SSS   " + args);
    }
    private void printNum2(int args)
    {
        Debug.Log("222    " + args);

    }
    // Use this for initialization
    void Start()
    {
        myDelegate = printNum;
        myDelegate(1);
        Debug.Log("**********************************");
        myDelegate += printNum2;
        myDelegate(2);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
