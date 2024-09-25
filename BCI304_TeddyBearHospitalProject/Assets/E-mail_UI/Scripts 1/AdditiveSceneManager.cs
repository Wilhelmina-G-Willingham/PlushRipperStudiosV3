using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdditiveSceneManager : MonoBehaviour
{
    public string sceneName;             // Name of the additive scene to load
    public Button acceptButton;          // Button to trigger the loading of the additive scene

    private void Start()
    {
        // Add a listener to the accept button to load the additive scene
        if (acceptButton != null)
        {
            acceptButton.onClick.AddListener(OnAcceptButtonPressed);
        }
    }

    private void OnAcceptButtonPressed()
    {
        // Ensure the cursor is visible and unlocked
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Load the additive scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        Debug.Log("Additive scene loaded, cursor is visible.");
    }
}
