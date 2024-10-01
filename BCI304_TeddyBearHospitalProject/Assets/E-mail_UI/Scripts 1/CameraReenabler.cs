using UnityEngine;

public class CameraReenabler : MonoBehaviour
{
    public GameObject playerCamera;          // Reference to the Player Camera
    public Canvas notificationCanvas;        // Canvas for the notification
    public GameObject notificationPopup;     // Notification popup object
    private bool hasActivatedNotification = false;  // To ensure the notification triggers only once

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

        // Ensure the notification is hidden initially
        if (notificationCanvas != null)
        {
            notificationCanvas.gameObject.SetActive(false);
            Debug.Log("Notification canvas hidden at the start.");
        }

        if (notificationPopup != null)
        {
            notificationPopup.SetActive(false);
            Debug.Log("Notification popup hidden at the start.");
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

            // Trigger notification if this is the first time
            if (!hasActivatedNotification)
            {
                ActivateNotification();
                hasActivatedNotification = true;
                Debug.Log("Notification triggered for the first time.");
            }
        }
    }

    private void ActivateNotification()
    {
        // Ensure the notification canvas and popup are assigned and activate them
        if (notificationCanvas != null && notificationPopup != null)
        {
            notificationCanvas.gameObject.SetActive(true);
            notificationPopup.SetActive(true);
            Debug.Log("Notification popup and canvas displayed.");
        }
        else
        {
            Debug.LogWarning("Notification Canvas or Popup is not assigned.");
        }
    }
}
