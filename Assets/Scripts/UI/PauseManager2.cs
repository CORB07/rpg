
using UnityEngine;



    public class PauseManager : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        private bool isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) // ENTER key
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        void PauseGame()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f; // freezes all movement
            isPaused = true;
        }

        void ResumeGame()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f; // resumes time
            isPaused = false;
        }
    }
