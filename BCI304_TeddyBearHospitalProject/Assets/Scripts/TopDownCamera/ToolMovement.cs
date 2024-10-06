using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMovement : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject parentLocation;    // Reference to the original parent location

    [SerializeField]
    private float targetHeight = 6f;      // Target height for the tool when interacting

    [SerializeField]
    private AudioClip[] returnSoundClips; // Array of audio clips to play when the tool returns

    private Vector3 originalPosition;     // The original position of the tool
    private AudioSource audioSource;      // Audio source for playing the sound

    // Called when the object is picked up (interacted with)
    public void Interact()
    {
        // Move the object in relation to the mouse
        Vector3 objectPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(objectPos);
        transform.position = new Vector3(worldPos.x, targetHeight, worldPos.z);

        Cursor.visible = false;
    }

    // Called when left click is released
    public void OneClickInteract()
    {
        // Move the tool back to its original position
        transform.position = parentLocation.transform.position;
        Cursor.visible = true;

        // Play a random return sound if audio clips are assigned and the audio source exists
        if (returnSoundClips.Length > 0 && audioSource != null)
        {
            int randomIndex = Random.Range(0, returnSoundClips.Length);  // Select a random clip
            AudioClip clipToPlay = returnSoundClips[randomIndex];
            audioSource.PlayOneShot(clipToPlay);  // Play the selected sound
        }
    }

    private void Start()
    {
        // Store the original position of the tool for reference (optional)
        originalPosition = transform.position;

        // Initialize the audio source component
        audioSource = GetComponent<AudioSource>();

        // Ensure the audio source component is added to the tool GameObject
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
}
