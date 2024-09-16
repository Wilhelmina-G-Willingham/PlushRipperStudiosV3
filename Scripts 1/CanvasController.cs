using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasController : MonoBehaviour
{
    public Canvas canvasToControl;       // The Canvas you want to show/hide
    public Canvas videoCanvas;           // The Canvas that contains the VideoPlayer
    public VideoPlayer videoPlayer;      // The VideoPlayer component on the videoCanvas
    public Button hideButton;            // The Button that hides the canvasToControl
    public GameObject tutorialPopup;     // The Tutorial Popup GameObject to hide

    private bool hasPlayed = false;      // Tracks if the video has already played
    private Camera playerCamera;         // Reference to the camera with the PlayerCamera tag

    private void Start()
    {
        // Find the camera tagged as PlayerCamera and get the Camera component
        GameObject cameraObject = GameObject.FindGameObjectWithTag("PlayerCamera");
        if (cameraObject != null)
        {
            playerCamera = cameraObject.GetComponent<Camera>();
        }

        // Disable both Canvases at the start
        if (canvasToControl != null)
        {
            canvasToControl.gameObject.SetActive(false);
        }

        if (videoCanvas != null)
        {
            videoCanvas.gameObject.SetActive(false);
        }

        // Add a listener to the button to hide the Canvas
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(HideCanvas);
        }

        // Allow the VideoPlayer to loop
        if (videoPlayer != null)
        {
            videoPlayer.isLooping = true;
        }
    }

    private void Update()
    {
        if (playerCamera != null)
        {
            // Check for mouse click on the GameObject this script is attached to
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                RaycastHit hit;
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

                    if (hit.collider.gameObject == this.gameObject)
                    {
                        HandlePCClick();
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("PlayerCamera not found. Ensure the camera is tagged correctly.");
        }
    }

    private void HandlePCClick()
    {
        Debug.Log("PC clicked");

        // Hide the tutorial popup when the PC is clicked
        if (tutorialPopup != null)
        {
            tutorialPopup.SetActive(false);
        }

        if (!hasPlayed && videoCanvas != null && videoPlayer != null)
        {
            PlayVideo();
        }
        else
        {
            ShowCanvas();
        }
    }

    private void PlayVideo()
    {
        videoCanvas.gameObject.SetActive(true);
        videoPlayer.Play();
        hasPlayed = true;

        // Start a coroutine to disable the video canvas after 6 seconds
        StartCoroutine(DisableVideoCanvasAfterDelay(6f));

        Debug.Log("Video started playing.");
    }

    private System.Collections.IEnumerator DisableVideoCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        videoCanvas.gameObject.SetActive(false);
        ShowCanvas();

        Debug.Log("Video canvas disabled after delay and main canvas enabled.");
    }

    private void ShowCanvas()
    {
        if (canvasToControl != null)
        {
            canvasToControl.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void HideCanvas()
    {
        if (canvasToControl != null)
        {
            canvasToControl.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

