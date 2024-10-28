using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera not found. Make sure there is a camera tagged as 'MainCamera' in the scene.");
        }
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // Rotate the particle system to always face the camera
            transform.LookAt(mainCamera.transform);
        }
    }
}

