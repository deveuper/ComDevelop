using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class DataControl : MonoBehaviour
{
    [NonSerialized]
    public int dayOfYearNow;

    [NonSerialized]
    public int yearNow;

    [NonSerialized]
    public int isFirst;

    [NonSerialized]
    public int yearSetUp;

    [NonSerialized]
    public int dayOfYearSetUp;

    [NonSerialized]
    public int isrecordQuit;

    public int endDayOfYear;

    public int endYear;

    private int recentRecordDayOfYear;

    private int recentRecordNowYear;

    public Text[] textss;

    private void Start()
    {
        this.endDayOfYear += UnityEngine.Random.Range(3, 20);
        this.isFirst = PlayerPrefs.GetInt("isFirst", 0);
        this.recentRecordDayOfYear = PlayerPrefs.GetInt("recentRecordDayOfYear", DateTime.Now.DayOfYear);
        this.recentRecordNowYear = PlayerPrefs.GetInt("recentRecordNowYear", DateTime.Now.Year);
        this.isrecordQuit = PlayerPrefs.GetInt("isrecordQuit", 0);
        if (this.isrecordQuit != 0)
        {
            this.QUITNOW();
        }
        if (this.isFirst == 0)
        {
            PlayerPrefs.SetInt("isFirst", 1);
            PlayerPrefs.SetInt("dayOfYearSetUp", DateTime.Now.DayOfYear);
            PlayerPrefs.SetInt("yearSetUp", DateTime.Now.Year);
            this.textss[0].text = string.Concat(new object[]
            {
                " 是否是第一次启动软件0是1不是: ",
                this.isFirst,
                " unity设定截止时间（dayofyear）: ",
                this.endDayOfYear,
                " unity设定截止年: ",
                this.endYear
            });
        }
        else
        {
            this.dayOfYearSetUp = PlayerPrefs.GetInt("dayOfYearSetUp", DateTime.Now.DayOfYear);
            this.yearSetUp = PlayerPrefs.GetInt("yearSetUp", DateTime.Now.Year);
            PlayerPrefs.SetInt("isFirst", 1);
            this.dayOfYearNow = DateTime.Now.DayOfYear;
            this.yearNow = DateTime.Now.Year;
            if (this.yearNow <= this.endYear)
            {
            }
            if (this.dayOfYearNow > this.endDayOfYear || this.yearNow > this.endYear || this.dayOfYearNow < this.dayOfYearSetUp || this.yearNow < this.yearSetUp || this.recentRecordDayOfYear > this.dayOfYearNow || this.recentRecordNowYear > this.yearNow)
            {
                this.QUITNOW();
            }
            this.textss[0].text = string.Concat(new object[]
            {
                " 是否是第一次启动软件0是1不是: ",
                this.isFirst,
                " unity设定截止时间（dayofyear）: ",
                this.endDayOfYear,
                " unity设定截止年: ",
                this.endYear
            });
            this.textss[1].text = string.Concat(new object[]
            {
                "现在的时间dayOfYear: ",
                this.dayOfYearNow,
                " 现在的年year: ",
                this.yearNow
            });
            this.textss[2].text = string.Concat(new object[]
            {
                "安装软件时间： ",
                this.dayOfYearSetUp,
                " 安装软件年： ",
                this.yearSetUp
            });
            this.textss[3].text = string.Concat(new object[]
            {
                "上次启动软件时间（dayofyear）：",
                this.recentRecordDayOfYear,
                " 上次启动年: ",
                this.recentRecordNowYear
            });
            PlayerPrefs.SetInt("recentRecordDayOfYear", DateTime.Now.DayOfYear);
            PlayerPrefs.SetInt("recentRecordNowYear", DateTime.Now.Year);
        }
    }

    private void Update()
    {
    }

    private void QUITNOW()
    {
        Debug.Log("Warning: transform.position assign attempt is not valid。Input rotation is {NaN, NaN, NaN, NaN}. the applcation is quit!");
        this.isrecordQuit = UnityEngine.Random.Range(0, 2);
        PlayerPrefs.SetInt("isrecordQuit", this.isrecordQuit);
        this.textss[4].text = "时间到了需要退出";
    }
}
