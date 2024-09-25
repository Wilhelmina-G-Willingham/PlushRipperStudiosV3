using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public string playerCameraTag = "PlayerCamera"; // Tag to identify the player camera

    private void Update()
    {
        // Check if no cameras are currently rendering
        if (Camera.allCameras.Length == 0 || Camera.main == null)
        {
            Debug.LogWarning("No cameras are rendering. Activating the player camera.");

            // Find the player camera GameObject
            GameObject playerCameraObject = GameObject.FindGameObjectWithTag(playerCameraTag);
            if (playerCameraObject != null)
            {
                // Activate the GameObject to ensure the camera is active
                playerCameraObject.SetActive(true);

                // Optionally: If the camera needs to be explicitly enabled, do so
                Camera playerCamera = playerCameraObject.GetComponent<Camera>();
                if (playerCamera != null)
                {
                    playerCamera.enabled = true;
                }

                Debug.Log("Player camera activated.");
            }
            else
            {
                Debug.LogWarning("No GameObject found with tag: " + playerCameraTag);
            }
        }
    }
}
