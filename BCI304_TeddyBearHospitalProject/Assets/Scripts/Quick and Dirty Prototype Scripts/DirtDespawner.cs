using UnityEngine;
using System.Collections;  // DONT DELETE THIS

public class DirtDespawner : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private AudioClip[] scrubClips; // Array of audio clips to choose from
    [SerializeField] private float shrinkDuration = 1f; // Duration for shrinking
    [SerializeField] private ParticleSystem dirtParticle; // Reference to the particle system

    // Static flag for despawning
    private static bool isAnyDirtDespawning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the dirt object!");
        }

        // Stop the particle system at the start, if assigned
        if (dirtParticle != null)
        {
            dirtParticle.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            // Only allow despawning if no other dirt is currently despawning
            if (!isAnyDirtDespawning)
            {
                Debug.Log("Sphere collided with dirt!");

                // Choose a random scrub clip from the array
                if (scrubClips.Length > 0)
                {
                    AudioClip selectedClip = scrubClips[Random.Range(0, scrubClips.Length)];
                    SoundFXManager.instance.PlaySoundFXClip(selectedClip, transform, 1f); // Play the randomly selected audio clip
                }

                // Start the shrinking coroutine
                StartCoroutine(ShrinkAndDestroy());
            }
        }
    }

    private IEnumerator ShrinkAndDestroy()
    {
        isAnyDirtDespawning = true;
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0f;

        // Start the particle system when shrinking begins
        if (dirtParticle != null)
        {
            dirtParticle.transform.position = transform.position; // Position the particle system
            dirtParticle.Play(); // Start playing the particle effect
        }

        // Gradually shrink over the duration
        while (elapsedTime < shrinkDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / shrinkDuration;
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, progress);
            yield return null; // Wait until the next frame
        }

        transform.localScale = Vector3.zero;

        // Stop the particle system after shrinking
        if (dirtParticle != null)
        {
            dirtParticle.Stop();
        }

        Destroy(gameObject);

        isAnyDirtDespawning = false; // Reset the flag when despawning is complete
    }
}








