using UnityEngine;
using UnityEngine.UI;

public class SmoothCameraAndBearMover : MonoBehaviour
{
    public Transform cameraTransform;          // Reference to the Camera transform (the moving camera)
    public Transform sinkPosition;             // Target position the moving camera should move to face the sink
    public Transform workbenchPosition;        // Target position the moving camera should move back to the workbench
    public Transform bearTransform;            // Reference to the bear object
    public Transform bearSinkPosition;         // Target position where the bear should be at the sink
    public Transform bearWorkbenchPosition;    // Target position where the bear should be at the workbench

    public Button moveToSinkButton;            // UI Button to move the camera/bear to the sink
    public Button moveToWorkbenchButton;       // UI Button to move the camera/bear to the workbench

    public float moveSpeed = 2.0f;             // Speed at which the camera and bear move
    public float rotationSpeed = 2.0f;         // Speed at which the camera rotates
    private bool movingToSink = false;         // Flag to track whether the camera is moving to the sink
    private bool movingToWorkbench = false;    // Flag to track whether the camera is moving to the workbench

    private Quaternion initialRotation;        // Stores the initial rotation of the camera
    private Quaternion sinkRotation;           // Stores the target rotation for the sink (90 degrees Y-axis)

    private void Start()
    {
        // Add listeners to the buttons
        moveToSinkButton.onClick.AddListener(() => StartMovingToPosition(true));
        moveToWorkbenchButton.onClick.AddListener(() => StartMovingToPosition(false));

        // Store the initial rotation of the camera
        initialRotation = cameraTransform.rotation;

        // Set the sink target rotation (90 degrees on the Y axis relative to the original rotation)
        sinkRotation = Quaternion.Euler(0, initialRotation.eulerAngles.y + 90f, 0);
    }

    private void Update()
    {
        // Smoothly move the camera and bear between positions
        if (movingToSink)
        {
            SmoothMove(cameraTransform, sinkPosition);
            SmoothMove(bearTransform, bearSinkPosition);

            // Stop moving when the camera reaches the sink position
            if (HasReachedPosition(cameraTransform, sinkPosition))
            {
                // Rotate the camera to the sink's rotation
                SmoothRotate(cameraTransform, sinkRotation);
                if (HasReachedRotation(cameraTransform, sinkRotation))
                {
                    movingToSink = false; // Stop moving to sink when rotation is complete
                }
            }
        }
        else if (movingToWorkbench)
        {
            SmoothMove(cameraTransform, workbenchPosition);
            SmoothMove(bearTransform, bearWorkbenchPosition);

            // Stop moving when the camera reaches the workbench position and reset rotation
            if (HasReachedPosition(cameraTransform, workbenchPosition))
            {
                SmoothRotate(cameraTransform, initialRotation);
                if (HasReachedRotation(cameraTransform, initialRotation))
                {
                    movingToWorkbench = false; // Stop moving to workbench when rotation is complete
                }
            }
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
    }

    // Function to smoothly rotate a transform to a target rotation
    private void SmoothRotate(Transform objectToRotate, Quaternion targetRotation)
    {
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    // Check if the object has reached the target position
    private bool HasReachedPosition(Transform objectTransform, Transform targetPosition)
    {
        return Vector3.Distance(objectTransform.position, targetPosition.position) < 0.1f;
    }

    // Check if the object has reached the target rotation
    private bool HasReachedRotation(Transform objectTransform, Quaternion targetRotation)
    {
        return Quaternion.Angle(objectTransform.rotation, targetRotation) < 1f;
    }
}
