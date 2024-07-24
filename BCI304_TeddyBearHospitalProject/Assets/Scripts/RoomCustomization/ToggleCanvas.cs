using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
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

        // Add a CanvasGroup component if not already present
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Initially hide the Canvas and block raycasts
        canvas.enabled = false;
        isCanvasVisible = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    void Update()
    {
        // Check if the TAB key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the Canvas visibility
            isCanvasVisible = !isCanvasVisible;
            canvas.enabled = isCanvasVisible;
            canvasGroup.blocksRaycasts = isCanvasVisible;
            canvasGroup.interactable = isCanvasVisible;

            // Pause or resume the game
            Time.timeScale = isCanvasVisible ? 0 : 1;
        }
    }
}







