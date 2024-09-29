using UnityEngine;
using System.Collections.Generic;

public class AudioDampener : MonoBehaviour
{
    public float dampeningFactor = 0.5f;  // Value between 0 (mute) and 1 (full volume)

    private List<AudioSource> dampenedAudioSources = new List<AudioSource>();

    private void Start()
    {
        // Apply dampener to all initial audio sources
        ApplyDampenerToAllAudioSources();
    }

    private void Update()
    {
        // Continuously check for new audio sources that were not previously dampened
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            if (!dampenedAudioSources.Contains(audioSource))
            {
                // Apply the dampener to the new audio source
                ApplyDampener(audioSource);
                dampenedAudioSources.Add(audioSource);
            }
        }
    }

    private void ApplyDampenerToAllAudioSources()
    {
        // Get all active audio sources in the scene and apply dampener
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            ApplyDampener(audioSource);
            dampenedAudioSources.Add(audioSource);
        }
    }

    private void ApplyDampener(AudioSource audioSource)
    {
        // Apply the dampening factor to the volume without reducing it to zero
        if (audioSource != null)
        {
            audioSource.volume *= dampeningFactor;
        }
    }
}
