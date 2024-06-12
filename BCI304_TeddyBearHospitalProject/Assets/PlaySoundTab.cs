using UnityEngine;

public class PlaySoundOnTab : MonoBehaviour
{
    public AudioClip soundClip; // The sound clip to play
    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the sound clip to the AudioSource
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
        }
        else
        {
            Debug.LogWarning("Sound clip not assigned.");
        }
    }

    void Update()
    {
        // Check if the TAB key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or SoundClip is missing.");
        }
    }
}

