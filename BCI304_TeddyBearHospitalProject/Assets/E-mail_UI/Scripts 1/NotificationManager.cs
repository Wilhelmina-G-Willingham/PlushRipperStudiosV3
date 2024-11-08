using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject animationCanvas;          // Reference to the Animation Canvas
    public GameObject animationPanel;           // Specific panel that will hold the animation
    public AudioClip[] notificationSounds;      // Array of notification sound clips
    private AudioSource audioSource;            // AudioSource component to play sounds

    private void Start()
    {
        // Ensure the animation canvas and panel are hidden at the start
        if (animationCanvas != null)
        {
            animationCanvas.SetActive(false);    // Hide the animation canvas
        }

        if (animationPanel != null)
        {
            animationPanel.SetActive(false);     // Hide the animation panel
        }

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if missing
        }
    }

    // Method to show the animation immediately (no delay)
    public void ShowAnimation()
    {
        if (animationCanvas != null)
        {
            animationCanvas.SetActive(true);      // Unhide the animation canvas
            if (animationPanel != null)
            {
                animationPanel.SetActive(true);   // Unhide the animation panel
            }
            PlayNotificationSound();              // Play sound when the animation appears
            Debug.Log("Animation shown.");
        }
    }

    // Method to hide the animation
    public void HideAnimation()
    {
        if (animationCanvas != null)
        {
            animationCanvas.SetActive(false);     // Hide the animation canvas
            if (animationPanel != null)
            {
                animationPanel.SetActive(false);  // Hide the animation panel
            }
            Debug.Log("Animation hidden.");
        }
    }

    // Call this method when the PC is clicked
    public void OnPCClicked()
    {
        ShowAnimation();  // Show the animation
    }

    // Call this method when the reply button is pressed
    public void OnReplyButtonPressed()
    {
        HideAnimation();  // Hide the animation
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
