using UnityEngine;
using UnityEngine.UI;

public class DrawerOpenChecker : MonoBehaviour
{
    public Button addStuffingButton;  // Reference to the "Add Stuffing" button
    public Vector3 openPosition;      // Position to check if the drawer is open
    public float positionThreshold = 0.1f;  // Tolerance range for open position check

    private void Start()
    {
        // Ensure the button is hidden initially
        addStuffingButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the drawer is within the threshold of the open position
        if (Vector3.Distance(transform.position, openPosition) <= positionThreshold)
        {
            // Show the button when the drawer is open
            addStuffingButton.gameObject.SetActive(true);
        }
        else
        {
            // Hide the button if the drawer isn’t open
            addStuffingButton.gameObject.SetActive(false);
        }
    }
}
