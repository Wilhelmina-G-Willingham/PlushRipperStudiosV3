using UnityEngine;

public class SpongeMovement : MonoBehaviour
{
    private Vector3 startingPosition;
    private bool isHeld = false;
    private Rigidbody rb;
    private Vector3 initialOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity
        startingPosition = transform.position; // Store the starting position
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isHeld) // Check if left mouse button is pressed and sponge is not held
        {
            PickupSponge();
        }

        if (Input.GetMouseButtonUp(0) && isHeld) // Check if left mouse button is released and sponge is held
        {
            DropSponge();
        }

        if (isHeld)
        {
            MoveSponge();
        }
    }

    private void PickupSponge()
    {
        rb.velocity = Vector3.zero; // Stop any remaining velocity
        rb.angularVelocity = Vector3.zero; // Stop any rotation
        isHeld = true; // Set isHeld to true
        initialOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // Calculate the initial offset
    }

    private void DropSponge()
    {
        rb.velocity = Vector3.zero; // Stop any remaining velocity
        rb.angularVelocity = Vector3.zero; // Stop any rotation
        transform.position = new Vector3(transform.position.x, startingPosition.y, transform.position.z); // Maintain Y position
        isHeld = false; // Set isHeld to false
    }

    private void MoveSponge()
    {
        // Calculate the target position based on the mouse cursor position and the initial offset
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + initialOffset;
        targetPosition.y = startingPosition.y; // Maintain the Y position

        // Move the sponge to the target position
        rb.MovePosition(targetPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dirt")) // Check if the sponge collides with dirt
        {
            Destroy(other.gameObject); // Destroy the dirt object
        }
    }
}

































