using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class OpenEXE : MonoBehaviour
{
    string sss;
    string usingStr;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteAll();
        timeCount = Time.time + 5f;
        sss = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        int startIndex = sss.LastIndexOf('\\');
        UnityEngine.Debug.Log(sss + "  " + startIndex);
        sss = sss.Remove(startIndex);
        string useStr = sss + "\\CarrEnglishVersion\\CarrRepairEXE\\CarrRepairEXE.exe";
        usingStr = useStr;


        Process s = Process.Start(useStr);
        s.WaitForExit(6000);
        inputStr = sss;
        StartCoroutine(RepairDone());
    }
    public float timeCount;
    private void OnGUI()
    {
        //if (sss != null)
        //{
        //    GUI.Label(new Rect(10, 10, 1000, 20), sss);

        //}
        //if (usingStr != null)
        //{
        //    GUI.Label(new Rect(10, 40, 1000, 20), usingStr);
        //}
    }
    string inputStr;
    public void Update()
    {
        if (Time.time >= timeCount&& inputStr != null)
        {
            KillProcess("CarrRepairEXE");
            OpenRealExe(inputStr);
        }

    }


    private IEnumerator RepairDone()
    {
        yield return new WaitForEndOfFrame();
        //yield return StartCoroutine(RepairTime());
    }

    public void KillProcess(string ProcessName)
    {
        Process[] p = Process.GetProcessesByName(ProcessName);
        if (p.Length > 0)
        {
            try
            {
                p[0].Kill();
            }
            catch
            {

            }
        }
    }
    private void OpenRealExe(string inputStr)
    {
        inputStr = inputStr + "\\CarrEnglishVersion\\CarrEnglishVersion.exe";
        Process.Start(inputStr);
        Application.Quit();
    }

}
