using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using TMPro;

using Model;

namespace Manager
{
    public class JsonDataLoader : MonoBehaviour
    {
        public TMP_Text displayText;

        public Scrollbar scrollbar;

        void Start()
        {
            string filePath = Application.persistentDataPath + "/resultsData.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ResultData[] resultDataList = JsonConvert.DeserializeObject<ResultData[]>(json);

                string displayTextContent = "";
                foreach (ResultData data in resultDataList)
                {
                    displayTextContent += $"Score: {data.score}     ";
                    displayTextContent += $"Time: {data.time}       ";
                    displayTextContent += $"Name: {data.name}       ";
                    displayTextContent += $"Date: {data.date.Year}-{data.date.Month}-{data.date.Day}\n";
                }

                displayText.text = displayTextContent;
                LayoutRebuilder.ForceRebuildLayoutImmediate(displayText.rectTransform);
                scrollbar.value = 0;
            }
            else
            {
                Debug.LogError("JSON file not found!");
            }
            
        }
    }

}

