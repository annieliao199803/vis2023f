using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserData
{
    public string StudentID;
    public string Name;
    public ThemeModelDataWrapper MissionData;
}

//主題遊使用者資料
[Serializable]
public class ThemeModelDataItem
{
    public string MissionExhibitName;
    public bool IsMissionExhibitComplete;
    public DateTime MissionExhibitInitTime;
    public DateTime MissionExhibitEndTime;

    public ThemeModelDataItem(string name, bool isComplete, DateTime init, DateTime end)
    {
        MissionExhibitName = name;
        IsMissionExhibitComplete = isComplete;
        MissionExhibitInitTime = init;
        MissionExhibitEndTime = end;
    }
}


[Serializable]
public class ThemeModelDataWrapper
{
    public List<ThemeModelDataItem> themeModelDataItems;

    public ThemeModelDataWrapper(List<ThemeModelDataItem> items)
    {
        themeModelDataItems = items;
    }
}

//主題遊使用者資料
[Serializable]
public class ThemeModelSurveyDataItem
{
    public string Q1;
    public string Q2;
    public string Q3;
    public string Q4;
    public string Q5;
    public string Q6;
}