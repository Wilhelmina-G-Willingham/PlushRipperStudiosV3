using UnityEngine;
using System.Collections;  // DONT DELETE THIS

public class DirtDespawner : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private AudioClip[] scrubClips; // Array of audio clips to choose from
    [SerializeField] private float shrinkDuration = 1f; // Duration for shrinking

    // Static fwag UWU
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

        // Gradually shrink over the duration
        while (elapsedTime < shrinkDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / shrinkDuration;
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, progress);
            yield return null; // Wait until the next frame
        }

        transform.localScale = Vector3.zero;

        Destroy(gameObject);

        isAnyDirtDespawning = false; // Reset the flag when despawning is complete
    }
}








