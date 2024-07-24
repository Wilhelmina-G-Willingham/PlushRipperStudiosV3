using UnityEngine;

public class ChangeRoomMaterial : MonoBehaviour
{
    public Material newMaterial; // Material to apply
    public Renderer roomRenderer; // Reference to the Room_lp renderer
    public AudioClip soundClip; // Sound clip to play
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

    // Method to change the material and play sound
    public void ChangeMaterial()
    {
        if (newMaterial != null && roomRenderer != null)
        {
            roomRenderer.material = new Material(newMaterial); // Apply the new material
            Debug.Log("Applied material: " + newMaterial.name);
        }
        else
        {
            Debug.LogWarning("Material or Renderer is not assigned.");
        }

        PlaySound();
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



