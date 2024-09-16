using UnityEngine;

public class CameraReenabler : MonoBehaviour
{
    public string playerCameraTag = "PlayerCamera"; // The tag used to identify the player camera
    private Camera playerCamera;

    private void Start()
    {
        // Find the camera with the specified tag
        playerCamera = GameObject.FindGameObjectWithTag(playerCameraTag)?.GetComponent<Camera>();

        if (playerCamera == null)
        {
            Debug.LogWarning("No camera found with tag: " + playerCameraTag);
            return;
        }

        // Ensure the player camera is active at the start
        playerCamera.gameObject.SetActive(true);

        // Start the coroutine to periodically check camera status
        StartCoroutine(CheckCameras());
    }

    private System.Collections.IEnumerator CheckCameras()
    {
        while (true)
        {
            // Check if any cameras are rendering
            bool cameraRendering = false;
            foreach (Camera cam in Camera.allCameras)
            {
                if (cam.isActiveAndEnabled)
                {
                    cameraRendering = true;
                    break;
                }
            }

            // If no cameras are rendering, activate the player camera
            if (!cameraRendering && playerCamera != null)
            {
                playerCamera.gameObject.SetActive(true);
                Debug.Log("Player camera activated as no other cameras are rendering.");
            }

            // Wait for a short time before checking again
            yield return new WaitForSeconds(1f); // Adjust the interval as needed
        }
    }
}
