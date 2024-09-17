using UnityEngine;

public class ToggleFurnitureCanvas : MonoBehaviour
{
    public Canvas furnitureCanvas; // Furniture UI Canvas
    private CanvasGroup furnitureCanvasGroup;
    private bool isCanvasVisible;

    void Start()
    {
        // Initialize Furniture Canvas
        if (furnitureCanvas != null)
        {
            furnitureCanvasGroup = furnitureCanvas.GetComponent<CanvasGroup>();
            if (furnitureCanvasGroup == null)
            {
                furnitureCanvasGroup = furnitureCanvas.gameObject.AddComponent<CanvasGroup>();
            }
            furnitureCanvas.enabled = false;
            isCanvasVisible = false;
            furnitureCanvasGroup.blocksRaycasts = false;
            furnitureCanvasGroup.interactable = false;
        }
        else
        {
            Debug.LogError("Furniture Canvas is not assigned!");
        }
    }

    void Update()
    {
        // Toggle Furniture Canvas with CTRL key
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            ToggleCanvas();
        }
    }

    void ToggleCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        furnitureCanvas.enabled = isCanvasVisible;
        furnitureCanvasGroup.blocksRaycasts = isCanvasVisible;
        furnitureCanvasGroup.interactable = isCanvasVisible;
    }
}

