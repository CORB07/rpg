using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject deathScreenUI;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            ReturnToStartScreen();
        }
    }

    public void TriggerGameOver()
    {
        deathScreenUI.SetActive(true);
        isGameOver = true;

        // Optional: Pause time
        Time.timeScale = 0f;
    }

    public void ReturnToStartScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Screen"); // Replace with your actual scene name
        SceneManager.LoadScene("Start_Screen"); // Replace with your actual scene name
    }
}
