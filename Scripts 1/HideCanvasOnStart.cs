using UnityEngine;

public class HideCanvasOnStart : MonoBehaviour
{
    // Reference to the Canvas component
    private Canvas canvas;

    void Start()
    {
        // Get the Canvas component attached to the same GameObject
        canvas = GetComponent<Canvas>();

        // Check if the Canvas component is found
        if (canvas != null)
        {
            // Disable the Canvas at the start of the game
            canvas.enabled = false;
        }
        else
        {
            Debug.LogError("No Canvas component found on this GameObject!");
        }
    }
}
