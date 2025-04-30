
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScreenManager : MonoBehaviour
{
    public string nextSceneName = "Area 1";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
