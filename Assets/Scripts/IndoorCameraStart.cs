using UnityEngine;

public class IndoorCameraStart : MonoBehaviour
{
    public Vector2 indoorStartPosition = new Vector2(25f, 10f); // Set this to your desired indoor camera position

    void Start()
    {
        transform.position = new Vector3(indoorStartPosition.x, indoorStartPosition.y, -10f);
    }
}