using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOCData
{
    public Vector3 OriginPos = new();
    public float spacing = 0;
    public List<UserData> AllUserData = new List<UserData>();

    public int[] Q1 = new int[4] { 0, 0, 0, 0 };
    public int[] Q2 = new int[4] { 0, 0, 0, 0 };
    public int[] Q3 = new int[4] { 0, 0, 0, 0 };
    public int[] Q4 = new int[4] { 0, 0, 0, 0 };
    public int[] Q5 = new int[4] { 0, 0, 0, 0 };
    public int[] Q6 = new int[4] { 0, 0, 0, 0 };
}
