using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloadController : MonoBehaviour
{
    public string sceneToUnload;      // The name of the scene to unload
    public string playerCameraTag = "PlayerCamera"; // Tag to identify the player camera
    public GameObject buttonToHide;  // The button to hide after unloading the scene

    // This function is called to start the unloading process
    public void UnloadScene()
    {
        // Unload the specified scene asynchronously
        StartCoroutine(UnloadSceneAsync());
    }

    private System.Collections.IEnumerator UnloadSceneAsync()
    {
        // Lock the cursor to the center of the screen and hide it before unloading the scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Cursor locked to the center and hidden.");

        // Check if the scene is currently loaded
        if (SceneManager.GetSceneByName(sceneToUnload).isLoaded)
        {
            // Unload the specified scene
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneToUnload);

            // Wait until the asynchronous scene fully unloads
            while (!asyncUnload.isDone)
            {
                yield return null;
            }

            Debug.Log("Scene unloaded successfully.");

            // Find and enable the player camera by tag
            GameObject playerCameraObject = GameObject.FindGameObjectWithTag(playerCameraTag);
            if (playerCameraObject != null)
            {
                Camera playerCamera = playerCameraObject.GetComponent<Camera>();
                if (playerCamera != null)
                {
                    playerCamera.gameObject.SetActive(true);
                    Debug.Log("Switched back to the player camera.");
                }
                else
                {
                    Debug.LogWarning("No Camera component found on the GameObject with tag: " + playerCameraTag);
                }
            }
            else
            {
                Debug.LogWarning("No GameObject found with tag: " + playerCameraTag);
            }

            // Hide the button after unloading the scene
            if (buttonToHide != null)
            {
                buttonToHide.SetActive(false);
                Debug.Log("Button hidden.");
            }

            // Ensure the cursor is locked to the center of the screen after the scene is unloaded
            yield return null; // Wait for one frame to ensure everything is set up
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("Cursor lock state confirmed after unloading scene.");
        }
        else
        {
            Debug.LogWarning("The specified scene is not loaded or does not exist.");
        }
    }

}
