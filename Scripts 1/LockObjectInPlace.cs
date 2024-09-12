using UnityEngine;

public class LockObjectInPlace : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    private void Start()
    {
        // Store the initial position, rotation, and scale of the object
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }

    private void LateUpdate()
    {
        // Lock the object's position, rotation, and scale
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
    }
}
