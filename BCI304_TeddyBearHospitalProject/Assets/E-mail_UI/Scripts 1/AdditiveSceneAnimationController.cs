using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneAnimationController : MonoBehaviour
{
    public GameObject animationCanvas;          // Reference to the Animation Canvas
    public GameObject animationPanel;           // Specific panel that will hold the animation
    public AudioClip[] notificationSounds;      // Array of notification sound clips
    private AudioSource audioSource;            // AudioSource component to play sounds

    private bool isSceneUnloaded = false;

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

        // Subscribe to the scene unloading event
        SceneManager.sceneUnloaded += OnAdditiveSceneUnloaded;
    }

    // Method to show the animation when the additive scene is unloaded
    private void ShowAnimation()
    {
        if (animationCanvas != null)
        {
            animationCanvas.SetActive(true);      // Unhide the animation canvas
            if (animationPanel != null)
            {
                animationPanel.SetActive(true);   // Unhide the animation panel
            }
            PlayNotificationSound();              // Play sound when the animation appears
            Debug.Log("Animation shown after additive scene unloaded.");
        }
    }

    // Method to hide the animation when the reply button is pressed
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

    // Event handler for scene unloading
    private void OnAdditiveSceneUnloaded(Scene current)
    {
        if (!isSceneUnloaded) // Ensure this only runs once
        {
            ShowAnimation();  // Show the animation
            isSceneUnloaded = true;
        }
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

    // Unsubscribe from the event when the object is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnAdditiveSceneUnloaded;
    }
}
