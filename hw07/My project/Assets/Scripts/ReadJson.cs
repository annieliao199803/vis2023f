using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ReadJson : MonoBehaviour
{
    private string folderPath = "Assets/Data";
    //private List<DataStruct> dataList = new List<DataStruct>();
    public Dictionary<string, List<DataStruct>> dataDictionary = new Dictionary<string, List<DataStruct>>();
    public List<string> userEmail = new List<string>();

    void Start()
    {
        LoadJSONFiles();
    }

    void LoadJSONFiles()
    {
        string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

        foreach (string jsonFile in jsonFiles)
        {
            //Debug.Log("jsonFile: " + jsonFile);
            string jsonText = File.ReadAllText(jsonFile);
            //string wrapJson = "{\"Locations\":" + jsonText + "}";

            //Debug.Log(wrapJson);
            DataWrapper Datawrapper = JsonUtility.FromJson<DataWrapper>(jsonText);

            //Debug.Log(Datawrapper.Locations.Length);
            DataStruct[] dataArray = Datawrapper.dataList;


            List<DataStruct> dataList = new List<DataStruct>();
            foreach (DataStruct data in dataArray)
            {
                dataList.Add(data);
            }
            if (!userEmail.Contains(dataList[0].Email))
            {
                userEmail.Add(dataList[0].Email);
                dataDictionary.Add(dataList[0].Email, dataList);
            }
        }
    }
}