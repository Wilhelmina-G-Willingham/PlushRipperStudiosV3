using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMovement : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject parentLocation;

    [SerializeField]
    private float targetHeight = 6f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position; // Store the original position
    }

    // When the object is held, move in relation to the mouse
    public void Interact()
    {
        Vector3 objectPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(objectPos);
        transform.position = new Vector3(worldPos.x, targetHeight, worldPos.z);

        Cursor.visible = false;
    }

    // When left click is let go, spawn back the object to its original position
    public void OneClickInteract()
    {
        transform.position = originalPosition; // Move back to the original position
        Cursor.visible = true;
    }
}

