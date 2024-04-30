using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera topDownCamera;
    public Camera cornerCamera;

    void Start()
    {
        // Ensure only the top down camera is active at start
        topDownCamera.enabled = true;
        cornerCamera.enabled = false;
    }

    void Update()
    {
        // Check if the TAB button is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle camera states
            topDownCamera.enabled = !topDownCamera.enabled;
            cornerCamera.enabled = !cornerCamera.enabled;
        }
    }
}



