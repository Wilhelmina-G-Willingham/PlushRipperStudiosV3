using UnityEngine;

public class EmailPopupManager : MonoBehaviour
{
    [SerializeField] private Transform canvasTransform; // The Canvas to instantiate the popup on

    private GameObject currentPopup;

    // Method to be called on button click
    public void OpenEmailPopup(Email email)
    {
        if (email.emailPopupPrefab != null && canvasTransform != null)
        {
            // Check if there's already a popup open and close it
            if (currentPopup != null)
            {
                Destroy(currentPopup);
            }

            // Instantiate the EmailPopup prefab
            currentPopup = Instantiate(email.emailPopupPrefab, canvasTransform, false);

            // Set up the accept button
            AcceptButtonScript acceptButtonScript = currentPopup.GetComponentInChildren<AcceptButtonScript>();
            if (acceptButtonScript != null)
            {
                acceptButtonScript.Setup(email.emailPrefab, currentPopup);
            }
            else
            {
                Debug.LogError("AcceptButtonScript not found on the prefab.");
            }
        }
        else
        {
            Debug.LogError("emailPopupPrefab or canvasTransform is not assigned.");
        }
    }

    [System.Serializable]
    public class Email
    {
        public Sprite emailAsset;    // Asset to represent the email
        public GameObject emailPopupPrefab; // Prefab to be opened for this email
        public GameObject emailPrefab; // Prefab to be moved to the archive
    }
}
