using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

using Model;
using Controller;

namespace View
{
    public class SaveGameView : MonoBehaviour
    {
        public TMP_Text scoreField;
        public TMP_Text timeField;

        public TMP_InputField nameInputField;

        public Button saveButton;
        private bool isSave;
        public SaveGameController saveGameController;


        void Start()
        {
            Debug.Log("Scen save started");
            Debug.Log($"Cpre: {SaveGameData.Instance.score}");
            Debug.Log($"time: {SaveGameData.Instance.time}");
            scoreField.text = string.Format("Score: {0}", SaveGameData.Instance.score);
            timeField.text = string.Format("Time: {0}", SaveGameData.Instance.time);
            nameInputField.characterLimit = 10;
            saveButton.onClick.AddListener(OnSaveButtonClicked);
            saveButton.interactable = false; // Начально делаем кнопку неактивной
            //saveGameController = new SaveGameController();
        }

        void Update()
        {
            if (!isSave)
            {
                OnNameFieldChanged();
            }
            
        }

        public void OnSaveButtonClicked()
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.Log("Dield empty.");
                return;
            }
            SaveGameData.Instance.name = nameInputField.text;
            SaveGameData.Instance.date = DateTime.Now;
            Debug.Log($"SaveCpre: {SaveGameData.Instance.score}");
            Debug.Log($"Savetime: {SaveGameData.Instance.time}");
            Debug.Log($"SaveName: {SaveGameData.Instance.name}");
            Debug.Log($"SaveName: {SaveGameData.Instance.date}");
            // Вызов контроллера для сохранения данных
            saveGameController.SaveGame(SaveGameData.Instance.score, SaveGameData.Instance.time, SaveGameData.Instance.name, SaveGameData.Instance.date);
            isSave = true;
            saveButton.interactable = false;
        }

        public void OnNameFieldChanged()
        {
            if (string.IsNullOrEmpty(nameInputField.text))
            {
                saveButton.interactable = false; // Если поле пустое, делаем кнопку неактивной
            }
            else
            {
                saveButton.interactable = true; // Если поле заполнено, делаем кнопку активной
            }
        }
    }
}
