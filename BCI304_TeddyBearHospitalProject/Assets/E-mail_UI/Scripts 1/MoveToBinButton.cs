using UnityEngine;
using UnityEngine.UI;

public class MoveToBinButton : MonoBehaviour
{
    [SerializeField] private GameObject emailEntry; // The email entry object to move
    [SerializeField] private Transform contentBin;   // The Transform for ContentBin in the UI

    // Method to be called on button click
    public void OnClick()
    {
        if (emailEntry != null && contentBin != null)
        {
            // Move the email entry to the ContentBin
            emailEntry.transform.SetParent(contentBin, false);

            // Optionally, ensure the email entry is visible in the ContentBin
            emailEntry.SetActive(true);

            Debug.Log("Email moved to bin.");
        }
        else
        {
            Debug.LogError("EmailEntry or ContentBin is not assigned.");
        }
    }
}
