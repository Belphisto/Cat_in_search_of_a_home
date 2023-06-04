using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class MainMenuController : MonoBehaviour
    {
        public Button viewRecordsButton;
        public Button exitButton;

        public Button startGameButton;

        public Button preStartGameButton;

        public GameObject startStorePanel;
        
        // Start is called before the first frame update
        void Start()
        {
            viewRecordsButton.onClick.AddListener(OnViewRecordsButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            startGameButton.onClick.AddListener(OnStartGameButtonClicked);
            preStartGameButton.onClick.AddListener(OnPreStartGameButtonClicked);
        }

        private void OnViewRecordsButtonClicked()
        {
            // Загрузить сцену просмотра таблицы рекордов
            SceneManager.LoadScene("RecordsScene",LoadSceneMode.Single);
        }
        private void OnExitButtonClicked()
        {
            // Выйти из игры
            Application.Quit();
        }

        private void OnStartGameButtonClicked()
        {
            SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
        }

        private void OnPreStartGameButtonClicked()
        {
            startStorePanel.SetActive(true);
        }
    }

}
