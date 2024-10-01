using UnityEngine;

public class NotificationController : MonoBehaviour
{
    public GameObject notificationCanvas; // Reference to the Notification Canvas

    private void Start()
    {
        // Ensure the notification canvas is hidden at the start
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas
        }
    }

    // Method to show the notification
    public void ShowNotification()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(true); // Unhide the notification canvas
            Debug.Log("Notification shown.");
        }
    }

    // Method to hide the notification
    public void HideNotification()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas
            Debug.Log("Notification hidden.");
        }
    }

    // Call this method when the PC is clicked
    public void OnPCClicked()
    {
        // Show the notification
        ShowNotification();
    }

    // Call this method when the reply button is pressed
    public void OnReplyButtonPressed()
    {
        // Hide the notification
        HideNotification();
    }
}
