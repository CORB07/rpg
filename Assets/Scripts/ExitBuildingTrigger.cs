using UnityEngine;

public class ExitBuildingTrigger : MonoBehaviour
{
    public CameraScreenScroller cameraScroller;
    public Transform player;
    public Vector2 exitPosition = new Vector2(-16f, -10f); // Change this to your desired exit spot

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Move player first
            player.position = exitPosition;

            // Now reactivate camera logic
            cameraScroller.cameraActive = true;
            cameraScroller.ForceRefresh();
        }
    }
}