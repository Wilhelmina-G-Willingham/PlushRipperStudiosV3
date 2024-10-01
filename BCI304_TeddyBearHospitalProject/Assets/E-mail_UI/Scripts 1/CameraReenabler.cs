using UnityEngine;

public class CameraReenabler : MonoBehaviour
{
    public GameObject playerCamera;          // Reference to the Player Camera
   
    private void Start()
    {
        // Check if the player camera exists
        if (playerCamera == null)
        {
            playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
            if (playerCamera == null)
            {
                Debug.LogError("Player camera not found! Make sure the camera is tagged 'PlayerCamera'.");
                return;
            }
        }

        
    }

    private void Update()
    {
        // Check if no cameras are rendering and the player camera is disabled
        if (Camera.allCameras.Length == 0 && !playerCamera.activeInHierarchy)
        {
            // Reactivate the player camera if none are rendering
            playerCamera.SetActive(true);
            Debug.Log("Player camera reactivated.");

            
        }
    }

   
}
