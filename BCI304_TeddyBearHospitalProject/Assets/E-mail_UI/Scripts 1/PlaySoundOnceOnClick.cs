using System.Collections;
using UnityEngine;

public class PlaySoundOnceOnCanvasUnhide : MonoBehaviour
{
    public GameObject targetCanvas;    // Assign the Canvas GameObject in the Inspector
    public AudioSource audioSource;    // Assign the AudioSource for playing the sound
    public AudioClip soundClip;        // Assign the AudioClip for the sound to play
    public float fadeDuration = 1f;    // Time it takes for the volume to fade to zero

    private bool soundPlayed = false;  // Flag to track if the sound has already been played
    private bool isFading = false;     // Flag to prevent multiple fade processes

    private void Start()
    {
        // Ensure the AudioSource is set up correctly
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();  // Add AudioSource if missing
        }

        if (audioSource != null && soundClip != null)
        {
            audioSource.clip = soundClip;  // Assign the clip to the AudioSource
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip missing on " + gameObject.name);
        }

        // Initially, ensure that the sound hasn't been played yet
        soundPlayed = false;
    }

    private void Update()
    {
        // Check if the target canvas has become active (unhidden) and the sound hasn't been played yet
        if (!soundPlayed && targetCanvas.activeSelf)
        {
            PlaySoundOnce();  // Play the sound
        }

        // Start fading out the sound when the canvas is hidden again
        if (soundPlayed && !targetCanvas.activeSelf && !isFading)
        {
            StartCoroutine(FadeOutSound());
        }
    }

    // Method to play the sound only once
    private void PlaySoundOnce()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.Play();  // Play the sound
            soundPlayed = true;  // Mark the sound as played
            Debug.Log("Sound played when canvas was unhidden.");
        }
    }

    // Coroutine to fade out the volume when the canvas is hidden
    private IEnumerator FadeOutSound()
    {
        isFading = true;
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);  // Gradually reduce the volume
            yield return null;
        }

        audioSource.volume = 0;  // Ensure the volume is set to zero at the end
        audioSource.Stop();      // Stop the audio after the fade-out is complete
        Debug.Log("Sound faded out when canvas was hidden.");

        isFading = false;  // Reset fading state
    }
}
