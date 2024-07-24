using UnityEngine;

public class DirtDespawner : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField]private AudioClip scrubClip;
    private void Start()
    {
        // Get the Rigidbody component attached to the dirt object
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Disable gravity for the Rigidbody
            rb.useGravity = false;
            // Freeze rotation to prevent the dirt object from rotating
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the dirt object!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere")) // Change "Sphere" to the tag of your sphere object
        {
            Debug.Log("Sphere collided with dirt!"); // Add a debug log to check if collision is detected
            Destroy(gameObject); // Despawn the dirt object
           
            //Call Sound Effects Manager
            SoundFXManager.instance.PlaySoundFXClip(scrubClip, transform, 1f);
        }
    }
}




