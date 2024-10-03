using System.Collections;
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
    public float rotationDuration = 1.5f;      // Duration for the smooth rotation
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
                movingToSink = false;
                StartCoroutine(SmoothRotate(cameraTransform, sinkRotation, rotationDuration)); // Start the smooth rotation coroutine
            }
        }
        else if (movingToWorkbench)
        {
            SmoothMove(cameraTransform, workbenchPosition);
            SmoothMove(bearTransform, bearWorkbenchPosition);

            // Stop moving when the camera reaches the workbench position and reset rotation
            if (HasReachedPosition(cameraTransform, workbenchPosition))
            {
                movingToWorkbench = false;
                StartCoroutine(SmoothRotate(cameraTransform, initialRotation, rotationDuration)); // Reset rotation to initial rotation
            }
        }
    }

    private void StartMovingToPosition(bool toSink)
    {
        movingToSink = toSink;
        movingToWorkbench = !toSink;
    }

    // Coroutine to smoothly rotate the camera
    private IEnumerator SmoothRotate(Transform objectToRotate, Quaternion targetRotation, float duration)
    {
        Quaternion startRotation = objectToRotate.rotation;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            objectToRotate.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        objectToRotate.rotation = targetRotation; // Ensure the final rotation is set
    }

    // Function to smoothly move a transform to a target position
    private void SmoothMove(Transform objectToMove, Transform targetPosition)
    {
        objectToMove.position = Vector3.Lerp(objectToMove.position, targetPosition.position, Time.deltaTime * moveSpeed);
    }

    // Check if the object has reached the target position
    private bool HasReachedPosition(Transform objectTransform, Transform targetPosition)
    {
        return Vector3.Distance(objectTransform.position, targetPosition.position) < 0.1f;
    }
}