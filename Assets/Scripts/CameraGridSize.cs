using UnityEngine;

public class CameraGridSize : MonoBehaviour
{
    public int gridHeight = 10;  // Number of tiles tall
    public int gridWidth = 14;   // Number of tiles wide
    public float tileSize = 1f;  // Set this to the size of one tile in world units

    void Start()
    {
        // Set the orthographic size based on grid height
        Camera.main.orthographicSize = (gridHeight * tileSize) / 2f;

        // Adjust camera width based on aspect ratio
        float aspectRatio = (float)Screen.width / Screen.height;
        float camWidth = gridHeight * aspectRatio;

        // If the width doesn't match, adjust the camera size
        if (camWidth < gridWidth)
        {
            Camera.main.orthographicSize = (gridWidth / aspectRatio) / 2f;
        }
    }
}

