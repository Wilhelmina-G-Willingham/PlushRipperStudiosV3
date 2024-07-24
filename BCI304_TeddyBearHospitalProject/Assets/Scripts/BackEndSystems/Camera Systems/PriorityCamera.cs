using UnityEngine;

public class LoadInCamera : MonoBehaviour
{
    public Camera loadInCamera; // Reference to the desired load-in camera

    void Start()
    {
        // Ensure the load-in camera is not null
        if (loadInCamera != null)
        {
            // Enable the load-in camera
            loadInCamera.enabled = true;
        }
        else
        {
            Debug.LogError("Load-in camera is not assigned!");
        }

        // Disable other cameras in the scene (optional)
        DisableOtherCameras();
    }

    // Disable other cameras in the scene
    void DisableOtherCameras()
    {
        Camera[] allCameras = Camera.allCameras;

        foreach (Camera camera in allCameras)
        {
            if (camera != loadInCamera)
            {
                camera.enabled = false;
            }
        }
    }
}

