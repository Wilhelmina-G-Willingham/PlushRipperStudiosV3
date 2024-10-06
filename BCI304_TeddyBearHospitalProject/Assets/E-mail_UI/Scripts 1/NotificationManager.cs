using UnityEngine;

public class NotificationController : MonoBehaviour
{
    public GameObject notificationCanvas;      // Reference to the Notification Canvas
    public AudioClip[] notificationSounds;     // Array of notification sound clips
    private AudioSource audioSource;           // AudioSource component to play sounds

    private void Start()
    {
        // Ensure the notification canvas is hidden at the start
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas
        }

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if missing
        }
    }

    // Method to show the notification immediately (no delay)
    public void ShowNotification()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(true);  // Unhide the notification canvas
            PlayNotificationSound();             // Play sound when the notification appears
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
        ShowNotification();  // Show the notification
    }

    // Call this method when the reply button is pressed
    public void OnReplyButtonPressed()
    {
        HideNotification();  // Hide the notification
    }

    // Play a random notification sound
    private void PlayNotificationSound()
    {
        if (notificationSounds.Length > 0 && audioSource != null)
        {
            int randomIndex = Random.Range(0, notificationSounds.Length);  // Select a random sound
            AudioClip clipToPlay = notificationSounds[randomIndex];
            audioSource.PlayOneShot(clipToPlay);  // Play the sound
        }
    }
}
