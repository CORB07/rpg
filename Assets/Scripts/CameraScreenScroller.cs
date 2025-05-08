using UnityEngine;

public class CameraScreenScroller : MonoBehaviour
{
    public Transform player;
    public float screenWidth = 14f;
    public float screenHeight = 10f;

    public Vector2 screenOrigin = new Vector2(-14f, -10f); // center of screen (0, 0)
    public bool cameraActive = false;

    private Vector2Int currentScreen;

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

    Vector2Int GetPlayerScreen()
    {
        // Offset player position relative to origin and divide by screen size
        float relativeX = player.position.x - screenOrigin.x;
        float relativeY = player.position.y - screenOrigin.y;

        int screenX = Mathf.RoundToInt(relativeX / screenWidth);
        int screenY = Mathf.RoundToInt(relativeY / screenHeight);

        return new Vector2Int(screenX, screenY);
    }

    void MoveCameraToScreen(Vector2Int screen)
    {
        // Calculate center of the target screen
        float camX = screenOrigin.x + screen.x * screenWidth;
        float camY = screenOrigin.y + screen.y * screenHeight;

        transform.position = new Vector3(camX, camY, transform.position.z);
    }

    public void ForceRefresh()
    {
        currentScreen = GetPlayerScreen();
        MoveCameraToScreen(currentScreen);
    }
}
