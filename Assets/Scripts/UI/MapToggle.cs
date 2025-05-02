
using UnityEngine;

public class MapToggle : MonoBehaviour
{
    public GameObject mapOverlay;

    private bool isVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isVisible = !isVisible;
            mapOverlay.SetActive(isVisible);

            if (isVisible)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }


        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f; // freezes all movement
    }

    void ResumeGame()
    { 
        Time.timeScale = 1f; // resumes time
    }
}
