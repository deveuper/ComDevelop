using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Open the multiple Camera Screen
/// </summary>
public class CameraMultiplyScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        for (int i = 1; i <= Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
