using UnityEngine;

public class MoveToArchiveScript : MonoBehaviour
{
    public Transform archiveContent; // Assign this via the Inspector
    public GameObject emailPrefab; // The email prefab to move and unhide

    // Call this method to move the email to the archive
    public void MoveToArchive()
    {
        if (archiveContent == null || emailPrefab == null)
        {
            Debug.LogError("Archive content or email prefab is not assigned.");
            return;
        }

        // Hide the email prefab in its current parent (e.g., Inbox)
        emailPrefab.SetActive(false);

        // Move the email prefab to the Archive content
        emailPrefab.transform.SetParent(archiveContent, false);

        // Unhide the email prefab in the Archive
        emailPrefab.SetActive(true);

        Debug.Log("Email moved to and unhidden in archive.");
    }
}
