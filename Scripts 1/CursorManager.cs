using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Canvas canvasToCheck;       // The canvas to monitor
    public string playerCameraTag = "PlayerCamera"; // Tag to identify the player camera

    void Update()
    {
        // Check if the canvas is hidden and the PlayerCamera is active
        if (canvasToCheck != null && !canvasToCheck.gameObject.activeInHierarchy)
        {
            GameObject playerCameraObject = GameObject.FindGameObjectWithTag(playerCameraTag);
            if (playerCameraObject != null)
            {
                Camera playerCamera = playerCameraObject.GetComponent<Camera>();
                if (playerCamera != null && playerCamera.isActiveAndEnabled)
                {
                    // Lock the cursor to the center and hide it
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                    Debug.Log("Cursor locked to the center and hidden.");
                }
                else
                {
                    Debug.LogWarning("PlayerCamera is not active or has no Camera component.");
                }
            }
            else
            {
                Debug.LogWarning("No GameObject found with tag: " + playerCameraTag);
            }
        }
    }
}
