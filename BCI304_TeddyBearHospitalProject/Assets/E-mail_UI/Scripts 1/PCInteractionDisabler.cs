using UnityEngine;
using UnityEngine.SceneManagement;

public class PCInteractionDisabler : MonoBehaviour
{
    public GameObject pc; // Reference to the PC object that needs to be disabled

    private Collider pcCollider; // Collider component on the PC (for physical interaction)
    private bool isSceneLoaded = false;

    private void Start()
    {
        // Get the Collider component from the PC GameObject
        pcCollider = pc.GetComponent<Collider>();

        // Register the sceneLoaded event handler
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Event handler when a scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Additive)
        {
            isSceneLoaded = true;
            DisablePCInteraction();
        }
    }

    // Disables PC interaction by disabling the Collider (you can extend this if needed)
    private void DisablePCInteraction()
    {
        if (pcCollider != null)
        {
            pcCollider.enabled = false;
        }
        else
        {
            Debug.LogWarning("No Collider found on PC object to disable!");
        }
    }

    // Call this function when you want to re-enable PC interaction (when the scene is unloaded)
    public void EnablePCInteraction()
    {
        if (pcCollider != null)
        {
            pcCollider.enabled = true;
        }
    }

    private void OnDestroy()
    {
        // Unregister the event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
