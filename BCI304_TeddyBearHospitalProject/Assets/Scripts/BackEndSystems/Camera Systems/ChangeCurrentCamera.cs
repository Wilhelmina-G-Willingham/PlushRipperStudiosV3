using UnityEngine;

public class CameraSwitcherAdvanced : MonoBehaviour
{
    public Camera[] cameras; // Array to hold references to all cameras
    private int currentCameraIndex = 0; // Index of the currently active camera

    void Start()
    {
        // Ensure there is at least one camera in the array
        if (cameras.Length == 0)
        {
            Debug.LogError("No cameras assigned to the CameraSwitcher script!");
            return;
        }

        // Activate the first camera (Camera1) on startup
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Switch to the next camera
            SwitchToNextCamera();
        }
    }

    void SwitchToNextCamera()
    {
        // Increment the current camera index
        currentCameraIndex++;

        // Wrap around to the first camera if we reached the end of the array
        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }

        // Activate the camera at the new index
        ActivateCamera(currentCameraIndex);
    }

    void ActivateCamera(int index)
    {
        // Deactivate all cameras
        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }

        // Activate the camera at the specified index
        cameras[index].enabled = true;
    }
}

