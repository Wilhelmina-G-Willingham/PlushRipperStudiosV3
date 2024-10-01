using UnityEngine;

public class NotificationTrigger : MonoBehaviour
{
    public GameObject notificationCanvas; // Reference to the Notification Canvas

    // Call this method when the button is pressed
    public void OnButtonPressed()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(true); // Unhide the notification canvas
            Debug.Log("Notification canvas unhidden.");
        }
    }
}
