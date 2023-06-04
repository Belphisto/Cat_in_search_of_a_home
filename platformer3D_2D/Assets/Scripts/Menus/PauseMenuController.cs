using UnityEngine;

using Controller;
namespace Manager
{
    public class PauseMenuController : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject pausePanel;

        void Start()
        {
            Resume();
        }

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;

        }

        public void Pause()
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
    }

}

