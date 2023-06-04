using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class LoadMainMenu : MonoBehaviour
    {
        public Button mainMenuButton;
        
        // Start is called before the first frame update
        void Start()
        {
            //MusicManager.instance.PlayMusic();
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            // Загрузить сцену главного меню
            SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
        }


        // Update is called once per frame
        void Update()
        {
            
        }
    }

}

