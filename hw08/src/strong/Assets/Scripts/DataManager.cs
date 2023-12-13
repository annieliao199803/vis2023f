using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    IOCData data;
    private void Awake()
    {
        data = GameContainer.Get<IOCData>();
        InitIOCData();
    }
    void Start()
    {
        
    }

    void InitIOCData()
    {
        string allDataPath = Path.Combine(Application.streamingAssetsPath, "AllData");

        if (Directory.Exists(allDataPath))
        {
            // 獲取所有資料夾路徑
            string[] folderPaths = Directory.GetDirectories(allDataPath);

            foreach (string folderPath in folderPaths)
            {
                UserData userData = new UserData();

                // 獲取資料夾名稱（學號_名字）
                string folderName = Path.GetFileName(folderPath);

                // 使用底線分割學號和名字
                string[] parts = folderName.Split('_');

                if (parts.Length == 2)
                {
                    string studentId = parts[0];
                    string studentName = parts[1];

                    userData.StudentID = studentId;
                    userData.Name = studentName;

                    Debug.Log($"學號: {studentId}, 名字: {studentName}");

                    ReadSurveyData(folderPath);

                    // 組合treasureMissiondata.json的完整路徑
                    string jsonFilePath = Path.Combine(folderPath, "treasureMissiondata.json");

                    if (File.Exists(jsonFilePath))
                    {
                        // 讀取JSON檔案內容
                        string json = File.ReadAllText(jsonFilePath);

                        // 解析JSON資料到C#物件
                        ThemeModelDataWrapper dataWrapper = JsonConvert.DeserializeObject<ThemeModelDataWrapper>(json);

                        // 在這裡你可以使用 dataWrapper.themeModelDataItems 存取資料
                        userData.MissionData = dataWrapper;
                        Debug.Log($"Read JSON from: {jsonFilePath}");
                    }
                    else
                    {
                        Debug.LogError($"treasureMissiondata.json not found in folder: {folderPath}");
                    }
                    data.AllUserData.Add(userData);
                }
                else
                {
                    Debug.LogWarning($"Invalid folder name format: {folderName}");
                }
            }
        }
        else
        {
            Debug.LogError("AllData folder not found!");
        }

        Debug.LogWarning($"Q1:非常不同意{data.Q1[0]}, 不同意{data.Q1[1]}, 同意{data.Q1[2]}, 非常同意{data.Q1[3]}");
        Debug.LogWarning($"Q2:非常不同意{data.Q2[0]}, 不同意{data.Q2[1]}, 同意{data.Q2[2]}, 非常同意{data.Q2[3]}");
        Debug.LogWarning($"Q3:非常不同意{data.Q3[0]}, 不同意{data.Q3[1]}, 同意{data.Q3[2]}, 非常同意{data.Q3[3]}");
        Debug.LogWarning($"Q4:非常不同意{data.Q4[0]}, 不同意{data.Q4[1]}, 同意{data.Q4[2]}, 非常同意{data.Q4[3]}");
        Debug.LogWarning($"Q5:非常不同意{data.Q5[0]}, 不同意{data.Q5[1]}, 同意{data.Q5[2]}, 非常同意{data.Q5[3]}");
        Debug.LogWarning($"Q6:非常不同意{data.Q6[0]}, 不同意{data.Q6[1]}, 同意{data.Q6[2]}, 非常同意{data.Q6[3]}");
    }

    void ReadSurveyData(string folderPath)
    {
        string jsonFilePath = Path.Combine(folderPath, "themeModelSurveyData.json");

        if (File.Exists(jsonFilePath))
        {
            // 讀取JSON檔案內容
            string json = File.ReadAllText(jsonFilePath);

            // 解析JSON資料到C#物件
            ThemeModelSurveyDataItem surveyData = JsonConvert.DeserializeObject<ThemeModelSurveyDataItem>(json);
            
            Count(surveyData);
        }
        else
        {
            Debug.LogError($"themeModelSurveyData.json not found in folder: {folderPath}");
        }
    }

    void Count(ThemeModelSurveyDataItem surveyData)
    {
        switch (surveyData.Q1)
        {
            case "StrongDisgree":
                data.Q1[0]++;
                break;
            case "Disgree ":
                data.Q1[1]++;
                break;
            case "Agree ":
                data.Q1[2]++;
                break;
            case "StrongAgree ":
                data.Q1[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q2)
        {
            case "StrongDisgree":
                data.Q2[0]++;
                break;
            case "Disgree ":
                data.Q2[1]++;
                break;
            case "Agree ":
                data.Q2[2]++;
                break;
            case "StrongAgree ":
                data.Q2[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q3)
        {
            case "StrongDisgree":
                data.Q3[0]++;
                break;
            case "Disgree ":
                data.Q3[1]++;
                break;
            case "Agree ":
                data.Q3[2]++;
                break;
            case "StrongAgree ":
                data.Q3[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q4)
        {
            case "StrongDisgree":
                data.Q4[0]++;
                break;
            case "Disgree ":
                data.Q4[1]++;
                break;
            case "Agree ":
                data.Q4[2]++;
                break;
            case "StrongAgree ":
                data.Q4[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q5)
        {
            case "StrongDisgree":
                data.Q5[0]++;
                break;
            case "Disgree ":
                data.Q5[1]++;
                break;
            case "Agree ":
                data.Q5[2]++;
                break;
            case "StrongAgree ":
                data.Q5[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q6)
        {
            case "StrongDisgree":
                data.Q6[0]++;
                break;
            case "Disgree ":
                data.Q6[1]++;
                break;
            case "Agree ":
                data.Q6[2]++;
                break;
            case "StrongAgree ":
                data.Q6[3]++;
                break;
            default:
                break;
        }
    }
}
