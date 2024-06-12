using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    private Canvas canvas;
    private bool isCanvasVisible;

    void Start()
    {
        // Get the Canvas component
        canvas = GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Canvas component not found!");
            return;
        }

        // Initially hide the Canvas
        canvas.enabled = false;
        isCanvasVisible = false;
    }

    void Update()
    {
        // Check if the TAB key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the Canvas visibility
            isCanvasVisible = !isCanvasVisible;
            canvas.enabled = isCanvasVisible;
        }
    }
}


