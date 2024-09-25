using UnityEngine;
using UnityEngine.UI;

public class PopupHandler : MonoBehaviour
{
    public Image popupPanel;       // The Image component representing the popup
    public Button closeButton;     // The button to close the popup
    public Canvas mainCanvas;      // The Canvas that triggers the popup

    private bool isFirstOpen = true; // Tracks if the popup has been shown for the first time

    void Start()
    {
        // Ensure the popup is initially hidden
        if (popupPanel != null)
        {
            popupPanel.gameObject.SetActive(false);
        }

        // Add a listener to the close button to hide the popup
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePopup);
        }
    }

    void Update()
    {
        // Check if the Canvas is opened (active)
        if (mainCanvas != null && mainCanvas.gameObject.activeSelf && isFirstOpen)
        {
            ShowPopup();
        }
    }

    private void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.gameObject.SetActive(true); // Show the popup
            isFirstOpen = false; // Mark that the popup has been shown
        }
    }

    private void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.gameObject.SetActive(false); // Hide the popup
        }
    }
}
