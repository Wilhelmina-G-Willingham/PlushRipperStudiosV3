using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NotificationController : MonoBehaviour
{
    public GameObject notificationCanvas;  // Reference to the Notification Canvas
    public AudioClip notificationSound;    // Reference to the notification sound (ping noise)
    public AudioSource audioSource;        // Audio source to play the sound
    public string additiveSceneName;       // Name of the additive scene to track

    private void Start()
    {
        // Ensure the notification canvas is hidden at the start
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas
        }

        // Subscribe to the scene unload event
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene unload event when the object is destroyed
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    // Method to detect when a scene is unloaded
    private void OnSceneUnloaded(Scene scene)
    {
        // Check if the unloaded scene is the specified additive scene
        if (scene.name == additiveSceneName)
        {
            ShowNotification();  // Show the notification when the scene is unloaded
        }
    }

    // Method to show the notification and play sound with a delay
    private void ShowNotification()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(true); // Unhide the notification canvas
            Debug.Log("Notification shown.");
            StartCoroutine(PlaySoundWithDelay(1f)); // Delay the sound by 1 second
        }
    }

    // Coroutine to play the sound with a delay
    private IEnumerator PlaySoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the delay duration
        if (audioSource != null && notificationSound != null)
        {
            audioSource.PlayOneShot(notificationSound); // Play the notification sound
            Debug.Log("Notification sound played after delay.");
        }
    }

    // Call this method when the reply button is pressed
    public void OnReplyButtonPressed()
    {
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas
            Debug.Log("Notification hidden.");
        }
    }
}
