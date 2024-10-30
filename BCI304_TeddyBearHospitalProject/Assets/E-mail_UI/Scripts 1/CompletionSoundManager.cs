using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Button moveToSinkButton;
    public BrownOverlayManager overlayManager; // Reference to BrownOverlayManager

    private void Start()
    {
        // Initially disable the button
        moveToSinkButton.interactable = false;

        // Subscribe to the OnSoundComplete event
        if (overlayManager != null)
        {
            overlayManager.OnSoundComplete += EnableButton;
        }
    }

    private void EnableButton()
    {
        // Enable the button once the sound has completed
        moveToSinkButton.interactable = true;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        if (overlayManager != null)
        {
            overlayManager.OnSoundComplete -= EnableButton;
        }
    }
}
