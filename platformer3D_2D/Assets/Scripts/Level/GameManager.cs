using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Controller;
using Model;
using View;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        private TimeController timeController;
        private ScoreController scoreController;
        //private LevelModel levelModel;

        public GameObject endStorePanel;

        private ScoreModel scoreModel;

        private TimeModel timeModel;
        private LevelModel levelModel;

        public Button continueStory;
        private BonusController[] bonusControllers;

        // Start is called before the first frame update
        private void Start()
        {
            //MusicManager.instance.PlayMusic();
            levelModel = new LevelModel(0);

            timeModel = new TimeModel();
            var timeView = FindObjectOfType<TimeView>();
            timeController = new TimeController(timeModel, timeView);

            scoreModel = new ScoreModel();
            var scoreView = FindObjectOfType<ScoreView>();  
            scoreController = new ScoreController(scoreModel, scoreView);

            bonusControllers = FindObjectsOfType<BonusController>();
            foreach (BonusController bonusController in bonusControllers)
            {
                bonusController.OnScoreAdded += AddScore; // Подписка на событие OnScoreAdded
                bonusController.OnLevelCompleted += LevelCompleted;
            }
            
            continueStory.onClick.AddListener(onClickContinue);
        }

        private void onClickContinue()
        {
            Debug.Log("onClickContinue()");
            SceneManager.LoadScene("SaveScene",LoadSceneMode.Single);
        }

        // Update is called once per frame

        private void Update()
        {
            timeController.UpdateTime();
            scoreController.UpdateScore();

        }

        public void SetScoreController(ScoreController controller)
        {
            scoreController = controller;
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void AddScore(int scoreValue)
        {
            scoreController.AddScore(scoreValue); // Добавление очков через ScoreController
        }

        private void LevelCompleted(int scoreValue)
        {
            Time.timeScale = 0; // Завершение уровня
            SaveGameData.Instance.score = scoreModel.GetScore();
            SaveGameData.Instance.time = timeModel.GetTime();
            SaveGameData.Instance.ID_Level = levelModel.GetLevelId();
            Debug.Log("SaveGameData???");
            endStorePanel.SetActive(true);
        }

    }

}

