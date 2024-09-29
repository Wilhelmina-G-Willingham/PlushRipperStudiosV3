using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupScreenManager : MonoBehaviour
{
    // Name of the scene to load when the Play button is pressed
    public string sceneToLoad;

    // Function to load the game scene
    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Function to quit the game
    public void QuitGame()
    {
        // This will only work in a built application, not in the editor
        Application.Quit();

        // In the Unity editor, use this to stop the game:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
