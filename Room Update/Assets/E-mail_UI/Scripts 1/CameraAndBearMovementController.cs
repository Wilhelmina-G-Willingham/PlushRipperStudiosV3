using UnityEngine;
using UnityEngine.UI;

public class SmoothCameraAndBearMover : MonoBehaviour
{
    public Transform cameraTransform;          // Reference to the Camera
    public Transform sinkPosition;             // Target position the camera should move to face the sink
    public Transform workbenchPosition;        // Target position the camera should move back to the workbench
    public Transform bearTransform;            // Reference to the bear object
    public Transform bearSinkPosition;         // Target position where the bear should be at the sink
    public Transform bearWorkbenchPosition;    // Target position where the bear should be at the workbench

    public Button moveToSinkButton;            // UI Button to move the camera/bear to the sink
    public Button moveToWorkbenchButton;       // UI Button to move the camera/bear to the workbench

    public float moveSpeed = 2.0f;             // Speed at which the camera and bear move
    private bool movingToSink = false;         // Flag to track whether the camera is moving to the sink
    private bool movingToWorkbench = false;    // Flag to track whether the camera is moving to the workbench

    private void Start()
    {
        // Add listeners to the buttons
        moveToSinkButton.onClick.AddListener(() => StartMovingToPosition(true));
        moveToWorkbenchButton.onClick.AddListener(() => StartMovingToPosition(false));
    }

    private void Update()
    {
        // Smoothly move the camera and bear between positions
        if (movingToSink)
        {
            SmoothMove(cameraTransform, sinkPosition);
            SmoothMove(bearTransform, bearSinkPosition);
        }
        else if (movingToWorkbench)
        {
            SmoothMove(cameraTransform, workbenchPosition);
            SmoothMove(bearTransform, bearWorkbenchPosition);
        }
    }

    private void StartMovingToPosition(bool toSink)
    {
        movingToSink = toSink;
        movingToWorkbench = !toSink;
    }

    // Function to smoothly move a transform to a target position
    private void SmoothMove(Transform objectToMove, Transform targetPosition)
    {
        objectToMove.position = Vector3.Lerp(objectToMove.position, targetPosition.position, Time.deltaTime * moveSpeed);
        objectToMove.rotation = Quaternion.Slerp(objectToMove.rotation, targetPosition.rotation, Time.deltaTime * moveSpeed);
    }
}
