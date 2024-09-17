using UnityEngine;

public class HideEmailOnAccept : MonoBehaviour
{
    public GameObject emailPrefab; // The email prefab that should be hidden

    // Method to hide the email prefab when the Accept button is clicked
    public void HideEmail()
    {
        if (emailPrefab != null)
        {
            emailPrefab.SetActive(false); // Hide the email prefab
            Debug.Log("Email has been hidden.");
        }
        else
        {
            Debug.LogError("Email prefab is not assigned.");
        }
    }
}
