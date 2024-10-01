using UnityEngine;

public class EmailClickHandler : MonoBehaviour
{
    public GameObject notificationCanvas; // Reference to the Notification Canvas

    // Call this method when the email is clicked
    public void OnEmailClicked()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas
            Debug.Log("Notification canvas hidden.");
        }
    }
}
