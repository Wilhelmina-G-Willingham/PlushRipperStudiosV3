using UnityEngine;

public class SendToArchive : MonoBehaviour
{
    public GameObject emailPrefab; // The email prefab to be moved
    public Transform contentArchive; // The ContentArchive where the email should be moved

    // Method to move the email prefab to ContentArchive when the button is clicked
    public void MoveToArchive()
    {
        if (emailPrefab != null && contentArchive != null)
        {
            // Re-parent the email prefab to the ContentArchive
            emailPrefab.transform.SetParent(contentArchive, false);

            

            Debug.Log("Email has been moved to the ContentArchive.");
        }
        else
        {
            Debug.LogError("Email prefab or ContentArchive is not assigned.");
        }
    }
}
