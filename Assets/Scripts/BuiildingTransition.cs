using UnityEngine;

public class BuildingTransition : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform player;
    public CameraScreenScroller cameraScroller;
    public Vector2 targetPosition;
    public bool enableGridCamera = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DoTransition());
        }
    }

    private System.Collections.IEnumerator DoTransition()
    {
        // Move the player to the target location
        player.position = targetPosition;

        // Wait one frame to ensure position is updated
        yield return null;

        // Enable or disable grid-based camera
        cameraScroller.cameraActive = enableGridCamera;

        if (enableGridCamera)
        {
            cameraScroller.ForceRefresh(); // snap to new screen if needed
        }
    }
}
