using UnityEngine;
using UnityEngine.SceneManagement;

public class PCAdditiveSceneController : MonoBehaviour
{
    public GameObject notificationCanvas;      // Reference to the Notification Canvas
    public Collider pcCollider;               // Reference to the PC's collider
    public string additiveSceneName;          // Name of the additive scene

    private bool isSceneLoaded = false;       // Flag to track whether the additive scene is loaded

    private void Start()
    {
        // Ensure the notification canvas is hidden at the start
        if (notificationCanvas != null)
        {
            notificationCanvas.SetActive(false); // Hide the notification canvas at the start
        }

        // Disable the PC collider initially if the scene is already loaded
        if (pcCollider != null)
        {
            pcCollider.enabled = true; // Ensure the PC collider is enabled by default
        }

        // Subscribe to the scene unloading event
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene unloading event to avoid memory leaks
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    // Method to handle the scene unloading event
    private void OnSceneUnloaded(Scene scene)
    {
        // Check if the unloaded scene matches the additive scene name
        if (scene.name == additiveSceneName)
        {
            // When the additive scene is unloaded, show the notification canvas
            if (notificationCanvas != null)
            {
                notificationCanvas.SetActive(true); // Show the notification canvas
                Debug.Log("Notification canvas shown after unloading scene: " + scene.name);
            }

            // Re-enable the PC collider when the additive scene is unloaded
            if (pcCollider != null)
            {
                pcCollider.enabled = true; // Re-enable the PC collider
                Debug.Log("PC collider re-enabled after unloading scene: " + scene.name);
            }
        }
    }

    // Method to load the additive scene
    public void LoadAdditiveScene()
    {
        if (!isSceneLoaded)
        {
            SceneManager.LoadScene(additiveSceneName, LoadSceneMode.Additive);

            // Disable the PC collider when the additive scene is loaded
            if (pcCollider != null)
            {
                pcCollider.enabled = false; // Disable the PC collider
                Debug.Log("PC collider disabled after loading additive scene.");
            }

            isSceneLoaded = true;
        }
    }

    // Method to unload the additive scene
    public void UnloadAdditiveScene()
    {
        if (isSceneLoaded)
        {
            SceneManager.UnloadSceneAsync(additiveSceneName);
            isSceneLoaded = false;
        }
    }
}
