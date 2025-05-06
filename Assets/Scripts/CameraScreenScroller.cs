
using UnityEngine;

public class CameraScreenScroller : MonoBehaviour
{
    public Transform player;
    public float screenWidth;   // Set in world units
    public float screenHeight;  // Set in world units

    private Vector2Int currentScreen;
    // Add this to the top of the class
    public bool cameraActive = true;

    void Update()
    {
        if (!cameraActive) return;

        Vector2Int newScreen = GetPlayerScreen();

        if (newScreen != currentScreen)
        {
            currentScreen = newScreen;
            MoveCameraToScreen(currentScreen);
        }
    }


    void Start()
    {
        yield return null;
        currentScreen = GetPlayerScreen();
        MoveCameraToScreen(currentScreen);

    }

   

    Vector2Int GetPlayerScreen()
    {
        int x = Mathf.FloorToInt(player.position.x / screenWidth);
        int y = Mathf.FloorToInt(player.position.y / screenHeight);
        return new Vector2Int(x, y);
    }

    void MoveCameraToScreen(Vector2Int screen)
    {
        Vector3 newPos = new Vector3(
            screen.x * screenWidth + screenWidth / 2f,
            screen.y * screenHeight + screenHeight / 2f,
            transform.position.z // Preserve Z
        );

        transform.position = newPos;
    }
}

