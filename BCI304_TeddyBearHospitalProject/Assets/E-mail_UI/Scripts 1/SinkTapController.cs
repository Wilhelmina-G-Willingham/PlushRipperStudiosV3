using UnityEngine;

public class SinkTapController : MonoBehaviour
{
    public GameObject tapKnob;                // The tap knob object
    public ParticleSystem waterParticles;     // The particle system for water effect
    public AudioSource waterSound;            // Optional: Audio source for water sound (if you want sound)

    private bool isWaterRunning = false;      // Flag to track if water is running

    private void Start()
    {
        // Ensure the particle system is off at the start
        if (waterParticles != null)
        {
            waterParticles.Stop();
        }

        // Ensure the water sound is off at the start
        if (waterSound != null)
        {
            waterSound.Stop();
        }
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if the tap knob is clicked
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == tapKnob)
                {
                    ToggleWaterEffect();
                }
            }
        }
    }

    // Toggles the water effect on or off
    private void ToggleWaterEffect()
    {
        isWaterRunning = !isWaterRunning;

        if (isWaterRunning)
        {
            if (waterParticles != null)
            {
                waterParticles.Play();  // Start water particle effect
            }

            if (waterSound != null)
            {
                waterSound.Play();      // Start water sound effect
            }

            Debug.Log("Water is now running.");
        }
        else
        {
            if (waterParticles != null)
            {
                waterParticles.Stop();  // Stop water particle effect
            }

            if (waterSound != null)
            {
                waterSound.Stop();      // Stop water sound effect
            }

            Debug.Log("Water is now off.");
        }
    }
}
