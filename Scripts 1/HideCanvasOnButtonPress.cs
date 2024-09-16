using UnityEngine;
using UnityEngine.UI;

public class HideCanvasOnButtonPress : MonoBehaviour
{
    public Canvas canvasToHide; // Assign the Canvas you want to hide in the Inspector
    public Button hideButton;   // Assign the Button that will trigger hiding the Canvas in the Inspector

    private void Start()
    {
        // Add a listener to the button to hide the Canvas when clicked
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(HideCanvas);
        }
    }

    private void HideCanvas()
    {
        if (canvasToHide != null)
        {
            canvasToHide.enabled = false;
        }
    }
}
