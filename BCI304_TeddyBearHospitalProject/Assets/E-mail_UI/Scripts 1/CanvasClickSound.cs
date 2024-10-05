using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasClickSound : MonoBehaviour
{
    public Canvas targetCanvas;           // Reference to the target canvas
    public AudioClip clickSound;          // Sound to play on canvas click
    public AudioSource audioSource;       // Audio source to play the sound

    private void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click occurred on the target canvas
            if (IsPointerOverCanvas())
            {
                // Play the click sound
                PlayClickSound();
            }
        }
    }

    // Method to check if the pointer is over the specific canvas
    private bool IsPointerOverCanvas()
    {
        // Ensure the target canvas is active and interactable
        if (targetCanvas != null && targetCanvas.gameObject.activeInHierarchy)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            // Create a list to hold the raycast results
            var raycastResults = new System.Collections.Generic.List<RaycastResult>();

            // Perform the raycast to check for UI elements under the pointer
            EventSystem.current.RaycastAll(pointerData, raycastResults);

            // Check if any of the raycast hits are part of the target canvas
            foreach (RaycastResult result in raycastResults)
            {
                if (result.gameObject.GetComponentInParent<Canvas>() == targetCanvas)
                {
                    return true; // Pointer is over the target canvas
                }
            }
        }
        return false; // Pointer is not over the canvas
    }

    // Method to play the click sound
    private void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or ClickSound is missing!");
        }
    }
}
