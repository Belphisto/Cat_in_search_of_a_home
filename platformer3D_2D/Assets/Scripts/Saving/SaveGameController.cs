using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using Manager;
using Model;

namespace Controller
{
public class SaveGameController : MonoBehaviour
{
    private string filePath;
    private List<ResultData> resultDataList;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/resultsData.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            resultDataList = JsonConvert.DeserializeObject<List<ResultData>>(json);
        }
        else
        {
            resultDataList = new List<ResultData>();
        }
    }

    public void SaveGame(int score, float time, string name, DateTime date)
    {
        // Создание экземпляра модели данных и установка параметров сохранения

        ResultData newResultData = new ResultData
        {
            score = score,
            time = time,
            name = name,
            date = date
        };

        // Сохранение JSON-строки в файл или другое хранилище
        
        AddResult(newResultData);
        Debug.Log("Game saved!");
    }

    public void AddResult(ResultData resultData)
    {
        resultDataList.Add(resultData);
        Debug.Log($"File created or located in {filePath}");
        string json = JsonConvert.SerializeObject(resultDataList, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public void AddResult(int score, float time, string name, DateTime date)
    {
        ResultData newResultData = new ResultData
        {
            score = score,
            time = time,
            name = name,
            date = date
        };
        resultDataList.Add(newResultData);

        // Сохранение данных в файл
        string json = JsonConvert.SerializeObject(resultDataList, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
}