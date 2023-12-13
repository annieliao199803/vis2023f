using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
[Serializable]
public class DataStruct
{
    public string Email;

    public string Floor;

    public float Pressure;

    public string Timestamp;

    public float X;

    public float Y;

    public float RotateY;

    public float Weight;

    public DataStruct(string email, string floor, float pressure, string timestamp, float x, float y, float rotateY, float weight)
    {
        Email = email;
        Floor = floor;
        Pressure = pressure;
        Timestamp = timestamp;
        X = x;
        Y = y;
        RotateY = rotateY;
        Weight = weight;
    }
}

[Serializable]
public class DataWrapper
{
    public DataStruct[] dataList;
}

[Serializable]
public class Visitor
{
    private string email;

    private string name;

    private Vector3 initPosition;

    private int currentIndex;

    private List<DataStruct> positionData;

    private GameObject vistorPrefab;
    private Vector3 velocity = Vector3.zero;
    public Visitor(List<DataStruct> data, GameObject vistorprefab)
    {
        positionData = data;
        vistorPrefab = vistorprefab;
        email = data[0].Email;
        name = email.Substring(0, email.IndexOf('@'));
        Debug.Log("Name: " + name);
        vistorPrefab.name = name;
        currentIndex = 0;
        initPosition = CalculatePosition();
        initPosition = new Vector3(positionData[currentIndex].X, 0.55f, positionData[currentIndex].Y);
        vistorPrefab.transform.position = initPosition;
        vistorPrefab.GetComponentInChildren<TextMeshProUGUI>().text = name;
    }

    public void UpdatePosition()
    {
        if (currentIndex < positionData.Count-1)
        {
            currentIndex++;
            //Debug.Log(currentIndex);
        }
        float floor = 0.55f;
        if(positionData[currentIndex].Floor == "1F")
        {
            floor = 0.55f;
        }
        else if(positionData[currentIndex].Floor == "2F")
        {
            floor = 30.55f;
        }
        else if(positionData[currentIndex].Floor == "3F")
        {
            floor = 60.55f;
        }
        else if(positionData[currentIndex].Floor == "4F")
        {
            floor = 90.55f;
        }
        else
        {
            floor = -100.0f;
        }
        Vector3 position = new Vector3(positionData[currentIndex].X, floor, positionData[currentIndex].Y);
        //vistorPrefab.transform.position = Vector3.Lerp(vistorPrefab.transform.position, position, 60.0f * Time.deltaTime);
        vistorPrefab.transform.position = position;
        Vector3 rotate = CalculateRotateY();
        vistorPrefab.transform.rotation = Quaternion.Euler(rotate);

    }

    public void UpdateVistorPosition()
    {
        float floor = 0.55f;
        if (positionData[currentIndex].Floor == "1F")
        {
            floor = 0.55f;
        }
        else if (positionData[currentIndex].Floor == "2F")
        {
            floor = 30.55f;
        }
        else if (positionData[currentIndex].Floor == "3F")
        {
            floor = 60.55f;
        }
        else if (positionData[currentIndex].Floor == "4F")
        {
            floor = 90.55f;
        }
        else
        {
            floor = -100.0f;
        }
        Vector3 position = new Vector3(positionData[currentIndex].X, floor, positionData[currentIndex].Y);
        vistorPrefab.transform.position = Vector3.MoveTowards(vistorPrefab.transform.position, position, 2.0f * Time.deltaTime);
        //vistorPrefab.transform.position = position;
        Vector3 rotate = CalculateRotateY();
        vistorPrefab.transform.rotation = Quaternion.Euler(rotate);
        if (currentIndex < positionData.Count - 1 && vistorPrefab.transform.position == new Vector3(positionData[currentIndex].X, floor, positionData[currentIndex].Y))
        {
            currentIndex++;
            //Debug.Log(currentIndex);
        }
    }

    private Vector3 CalculatePosition()
    {
        float minOriginX = 10.45f;
        float minOriginZ = -11.64f;

        float maxOriginX = 60.47f;
        float maxOriginZ = 15.91f;

        float minNewX = -254.06f;
        float minNewZ = -138.87f;

        float maxNewX = 254.06f;
        float maxNewZ = 143.02f;

        float originX = positionData[currentIndex].X;
        float originZ = positionData[currentIndex].Y;

        float percentageX = (originX - minOriginX) / (maxOriginX - minOriginX);
        float percentageZ = (originZ - minOriginZ) / (maxOriginZ - minOriginZ);

        float newValueX = minNewX + (percentageX * (maxNewX - minNewX));
        float newValueZ = minNewZ + (percentageZ * (maxNewZ - minNewZ));

        return new Vector3(newValueX, 4.42f, newValueZ);
    }

    private Vector3 CalculateRotateY()
    {
        Vector3 newRotate = new Vector3(0, positionData[currentIndex].RotateY * 180.0f, 0);
        return newRotate;
    }
}