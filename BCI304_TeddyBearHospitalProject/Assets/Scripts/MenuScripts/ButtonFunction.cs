using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnButtonPress : MonoBehaviour
{
    public Button yourButton;

    // le button
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
        SceneManager.LoadScene("CatFieldTest");
    }
}






