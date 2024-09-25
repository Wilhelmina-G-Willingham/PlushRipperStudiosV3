using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popupPanel; // Assign the popup panel (the tutorial window) in the Inspector
    public GameObject computer;   // Assign the computer (or the specific GameObject) in the Inspector

    void Start()
    {
        // Ensure the popup is active at the start
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
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
