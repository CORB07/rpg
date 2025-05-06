using UnityEngine;

public class InteriorCameraToggle : MonoBehaviour
{
    public CameraScreenScroller cameraScroller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraScroller.cameraActive = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraScroller.cameraActive = true;
        }
    }
}
