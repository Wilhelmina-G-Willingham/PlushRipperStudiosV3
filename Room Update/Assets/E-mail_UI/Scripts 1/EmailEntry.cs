using UnityEngine;
using UnityEngine.UI;
using static EmailPopupManager;

public class EmailEntry : MonoBehaviour
{
    [SerializeField] private EmailPopupManager popupManager; // Assign this in the Inspector
    [SerializeField] private Email email; // Assign this in the Inspector

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component is missing from the email entry.");
        }
    }

    private void Start()
    {
        button.onClick.AddListener(OpenEmailPopup);
    }

    private void OpenEmailPopup()
    {
        if (popupManager != null)
        {
            popupManager.OpenEmailPopup(email);
        }
        else
        {
            Debug.LogError("PopupManager is not assigned.");
        }
    }
}
