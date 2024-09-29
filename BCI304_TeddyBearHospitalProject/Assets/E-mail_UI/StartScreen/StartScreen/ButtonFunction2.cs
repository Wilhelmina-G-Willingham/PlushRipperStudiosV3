using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadKoalaSceneOnButtonPress : MonoBehaviour
{
    // i literally copied the same code from the other one lol
    public Button yourButton;

    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(LoadScene);
        }
        else
        {
            Debug.LogError("Button reference is not set in the Inspector");
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("WorkshopTest Main Scene");
    }
}

