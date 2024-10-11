using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popupPanel; // Assign the popup panel (the tutorial window) in the Inspector
    public GameObject computer;    // Assign the computer (or the specific GameObject) in the Inspector
    public Text tutorialText;      // Assign the Text component in the Inspector

    void Start()
    {
        // Ensure the popup is active at the start
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }

        // Start the coroutine to show the text after a delay
        StartCoroutine(ShowTextAfterDelay(0.5f));
    }

    private IEnumerator ShowTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (tutorialText != null)
        {
            tutorialText.gameObject.SetActive(true); // Show the text
        }
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == computer)
                {
                    ClosePopup();
                }
            }
        }
    }

    private void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false); // Hide the popup panel
        }
    }
}
