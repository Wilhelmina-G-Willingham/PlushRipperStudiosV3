using UnityEngine;
using TMPro;

public class CameraTextLoader : MonoBehaviour
{
    public Camera[] cameras; // Array to hold references to all cameras
    public TMP_Text textComponent; // Reference to the TextMeshPro component of the canvas

    void Start()
    {
        // Ensure there is at least one camera and a TextMeshPro component assigned
        if (cameras.Length == 0 || textComponent == null)
        {
            Debug.LogError("No cameras or TextMeshPro component assigned to the CameraTextLoader script!");
            return;
        }

        // Listen for changes in the active camera
        Camera.onPreCull += UpdateText;
    }

    void OnDestroy()
    {
        // Unsubscribe from the camera events when the script is destroyed
        Camera.onPreCull -= UpdateText;
    }

    void UpdateText(Camera currentCamera)
    {
        // Find the index of the current active camera
        int index = System.Array.IndexOf(cameras, currentCamera);

        // If the current camera is not found in the array, return
        if (index == -1)
        {
            Debug.LogError("Current camera not found in the cameras array!");
            return;
        }

        // Update the text based on the current active camera
        textComponent.text = "Current Camera: " + cameras[index].name;
    }
}


