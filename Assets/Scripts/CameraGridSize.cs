using UnityEngine;


[ExecuteAlways]
public class CameraGridSize : MonoBehaviour
{
    public float tileSize = 1f;
    public int verticalTiles = 10;

    void Update()
    {
        Camera cam = GetComponent<Camera>();
        if (cam != null && cam.orthographic)
        {
            cam.orthographicSize = (verticalTiles * tileSize) / 2f;
        }
    }
}