using UnityEngine;
using UnityEngine.UI;

public class DenyButtonScript : MonoBehaviour
{
    public Transform binContent; // Assign this via the Inspector
    private GameObject emailEntry;
    private GameObject popup;

    // Method to set up the email entry and popup references
    public void Setup(GameObject emailEntry, GameObject popup)
    {
        this.emailEntry = emailEntry;
        this.popup = popup;

        // Attach the OnDenyButtonClicked method to the button's onClick event
        GetComponent<Button>().onClick.AddListener(OnDenyButtonClicked);
    }

    private void OnDenyButtonClicked()
    {
        // Move the email entry to the Bin content
        if (emailEntry != null && binContent != null)
        {
            emailEntry.transform.SetParent(binContent, false);
            Debug.Log("Email moved to bin.");
        }

        // Close the popup
        if (popup != null)
        {
            Destroy(popup);
        }
    }
}
