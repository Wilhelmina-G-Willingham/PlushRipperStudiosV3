using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform endTransform; // Ending transform
    public float speed = 1.0f; // Speed of movement
    public AnimationCurve easingCurve; // Easing curve for smooth movement

    private Vector3 startPos; // Starting position
    private Quaternion startRot; // Starting rotation
    private float startTime; // Time when movement started

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        // Record the start time
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the endTransform is not assigned
        if (endTransform == null)
        {
            Debug.LogError("End Transform is not assigned!");
            return;
        }

        // Calculate the total distance
        float journeyLength = Vector3.Distance(startPos, endTransform.position);
        // Calculate the distance covered
        float distanceCovered = (Time.time - startTime) * speed;
        // Calculate the fraction of the journey completed
        float journeyFraction = distanceCovered / journeyLength;
        // Evaluate easing curve to apply smooth movement
        float easingValue = easingCurve.Evaluate(journeyFraction);
        // Move the camera towards the end point with easing
        transform.position = Vector3.Lerp(startPos, endTransform.position, easingValue);
        // Interpolate rotation
        Quaternion newRotation = Quaternion.Lerp(startRot, endTransform.rotation, easingValue);
        // Maintain the original forward direction of the camera
        Vector3 originalForward = transform.forward;
        transform.rotation = newRotation;
        // Restore the original forward direction
        transform.forward = originalForward;

        // Check if the journey is complete
        if (journeyFraction >= 1.0f)
        {
            // Optional: Perform actions after reaching the end point
            // Debug.Log("Camera reached the end point!");
        }
    }
}


























