using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMainMenuOnButtonPress : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(LoadMainMenu);
        }
        else
        {
            Debug.LogError("Button reference is not set in the Inspector");
        }
    }

    // load the MainMenu scene
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

