using UnityEngine;
using UnityEngine.UI;

public class AcceptButtonScript : MonoBehaviour
{
    public Transform archiveContent; // Assign this via the Inspector
    private GameObject emailEntry;
    private GameObject popup;

    // Method to set up the email entry and popup references
    public void Setup(GameObject emailEntry, GameObject popup)
    {
        this.emailEntry = emailEntry;
        this.popup = popup;

        // Attach the OnAcceptButtonClicked method to the button's onClick event
        GetComponent<Button>().onClick.AddListener(OnAcceptButtonClicked);
    }

    private void OnAcceptButtonClicked()
    {
        // Move the email entry to the Archive content
        if (emailEntry != null && archiveContent != null)
        {
            emailEntry.transform.SetParent(archiveContent, false);
            Debug.Log("Email moved to archive.");
        }

        // Close the popup
        if (popup != null)
        {
            Destroy(popup);
        }
    }
}
