using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrownOverlayManager : MonoBehaviour
{
    public List<GameObject> overlayTargets; // Objects to apply the overlay
    public Color overlayColor = new Color(0.6f, 0.3f, 0.1f, 0.5f); // Default overlay color
    public ParticleSystem completionParticle; // Particle effect to play from this object
    public AudioClip completionSound; // Sound to play when all dirt is gone

    private List<Renderer> overlayRenderers = new List<Renderer>();
    private AudioSource audioSource;
    private bool hasPlayedSound = false; // Flag to ensure sound plays only once

    void Start()
    {
        // Get the AudioSource component or add one if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Add overlay to specified objects
        foreach (GameObject target in overlayTargets)
        {
            Renderer renderer = target.GetComponent<Renderer>();
            if (renderer != null)
            {
                overlayRenderers.Add(renderer);
                ApplyOverlay(renderer);
            }
        }
    }

    void Update()
    {
        // Check if all objects with the "Dirt" tag are removed
        if (GameObject.FindGameObjectsWithTag("Dirt").Length == 0 && !hasPlayedSound)
        {
            RemoveOverlay();
            StartCoroutine(TriggerCompletionEffects());
            hasPlayedSound = true; // Set flag to prevent sound from playing again
        }
    }

    private void ApplyOverlay(Renderer renderer)
    {
        foreach (Material material in renderer.materials)
        {
            material.color = overlayColor;
        }
    }

    private void RemoveOverlay()
    {
        foreach (Renderer renderer in overlayRenderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = Color.white; // Reset to default color
            }
        }
        overlayRenderers.Clear();
    }

    private IEnumerator TriggerCompletionEffects()
    {
        // Play particle effect
        if (completionParticle != null)
        {
            ParticleSystem particleInstance = Instantiate(completionParticle, transform.position, transform.rotation);
            particleInstance.Play();
            Destroy(particleInstance.gameObject, 1f); // Destroy particle object after 1 second
        }

        // Play sound effect
        if (completionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(completionSound);
        }

        yield return new WaitForSeconds(1f);

        // Stop sound if it has a longer duration
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}





