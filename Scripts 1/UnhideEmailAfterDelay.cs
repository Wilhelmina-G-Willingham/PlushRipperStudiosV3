using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnhideEmailBeforeHideCanvas : MonoBehaviour
{
    public GameObject emailPrefab;    // The email prefab to unhide
    public Button hideCanvasButton;   // The button that hides the canvas
    public Canvas canvasToHide;       // The canvas that will be hidden

    private void Start()
    {
        // Ensure the email prefab is assigned and hidden at the start
        if (emailPrefab == null)
        {
            Debug.LogError("Email prefab is not assigned in the Inspector.");
            return;
        }

        emailPrefab.SetActive(false);
        Debug.Log("Email prefab is hidden at start.");

        // Ensure the hide canvas button is assigned
        if (hideCanvasButton == null)
        {
            Debug.LogError("Hide canvas button is not assigned in the Inspector.");
            return;
        }

        // Add a listener to the hide canvas button
        hideCanvasButton.onClick.AddListener(OnHideCanvasButtonPressed);
        Debug.Log("Hide canvas button listener added.");
    }

    private void OnHideCanvasButtonPressed()
    {
        Debug.Log("Hide canvas button pressed. Unhiding email prefab...");

        // Unhide the email prefab before hiding the canvas
        if (emailPrefab != null)
        {
            emailPrefab.SetActive(true);
            Debug.Log("Email prefab is now visible.");
        }
        else
        {
            Debug.LogError("Email prefab reference is lost or not assigned.");
        }

        // Hide the canvas after unhiding the email prefab
        if (canvasToHide != null)
        {
            canvasToHide.gameObject.SetActive(false);
            Debug.Log("Canvas is now hidden.");
        }
        else
        {
            Debug.LogError("Canvas reference is lost or not assigned.");
        }
    }
}
