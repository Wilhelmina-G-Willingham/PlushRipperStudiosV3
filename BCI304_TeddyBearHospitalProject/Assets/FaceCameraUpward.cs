using UnityEngine;

public class FaceCameraUpward : MonoBehaviour
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
            // Calculate the direction to the camera
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            // Calculate the rotation to look at the camera but keep the upward direction
            Quaternion lookRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
            transform.rotation = lookRotation;
        }
    }
}

