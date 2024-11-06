using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Allows the player to click and drag on the bear to rotate it, allowing access to different parts of the bear that might need to be repaired and/or cleaned.
/// </summary>
public class BearRotateScript : MonoBehaviour, IInteractible
{
    //Rotation speed for the bear's rotation around the workbench
    [SerializeField]
    float rotationspeed = 1f;

    //Get the mouse movement along the x and y axes, and lock the cursor while the mouse is being dragged on the bear
    public void Interact()
    {
        //get the Input of the mouse on the x and y axes and rotate the bear.
        float XAxisRotation = Input.GetAxis("Mouse X") * rotationspeed;
        float YAxisRotation = Input.GetAxis("Mouse Y") * rotationspeed;

        //lock cursor so the player's mouse stays inside the game window
        Cursor.lockState = CursorLockMode.Locked;
        transform.Rotate(Vector3.right, YAxisRotation);

        //Check if the player is holding down shift, and change left/right to forward/back
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.forward, XAxisRotation);
        }
        else
        {
            transform.Rotate(Vector3.up, XAxisRotation);
        }
    }
}