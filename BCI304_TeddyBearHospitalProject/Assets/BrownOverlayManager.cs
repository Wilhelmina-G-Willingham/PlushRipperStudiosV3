using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrownOverlayManager : MonoBehaviour
{
    public List<GameObject> overlayTargets;
    public Color overlayColor = new Color(0.6f, 0.3f, 0.1f, 0.5f);
    public ParticleSystem completionParticle;
    public AudioClip completionSound;

    private List<Renderer> overlayRenderers = new List<Renderer>();
    private AudioSource audioSource;
    private bool hasPlayedSound = false;

    // Event to signal that the sound has finished playing
    public event System.Action OnSoundComplete;

    void Start()
    {
        audioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();

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
        if (GameObject.FindGameObjectsWithTag("Dirt").Length == 0 && !hasPlayedSound)
        {
            RemoveOverlay();
            StartCoroutine(TriggerCompletionEffects());
            hasPlayedSound = true;
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
                material.color = Color.white;
            }
        }
        overlayRenderers.Clear();
    }

    private IEnumerator TriggerCompletionEffects()
    {
        if (completionParticle != null)
        {
            ParticleSystem particleInstance = Instantiate(completionParticle, transform.position, transform.rotation);
            particleInstance.Play();
            Destroy(particleInstance.gameObject, 1f);
        }

        if (completionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(completionSound);
            yield return new WaitForSeconds(completionSound.length); // Wait for sound to complete

            // Trigger the event after sound completion
            OnSoundComplete?.Invoke();
        }
    }
}

