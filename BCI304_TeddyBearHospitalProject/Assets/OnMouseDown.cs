using UnityEngine;

public class ToggleLightOnTabWithSound : MonoBehaviour
{
    private Light lightComponent;
    private AudioSource audioSource;

    [Tooltip("Assign a custom sound effect for toggling the light")]
    public AudioClip toggleSound;

    private void Start()
    {
        // Get the Light 
        lightComponent = GetComponent<Light>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (toggleSound != null)
        {
            audioSource.clip = toggleSound;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the light's enabled state
            lightComponent.enabled = !lightComponent.enabled;

            if (toggleSound != null)
            {
                audioSource.PlayOneShot(toggleSound);
            }
        }
    }
}





