using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// input manager for the topdown Camera Controller, allowing the player to use the mouse on the bear, tools, and drawers, and exit the firstperson camera with a button press
/// </summary>
public class TopDownCameraController : MonoBehaviour, IInteractible
{
    //reference to be filled with raycast
    private IInteractible selectedObject;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Detect Inputs from mouse and keyboard
    void Update()
    {
        //get mouse input (Left Click)
        if (Input.GetMouseButton(0))
        {
            if (selectedObject == null)
            { 
                GetInteractible();
            }

            if (selectedObject != null)
            {
                //call the object's click-and-hold Interact method
                Debug.Log("Object Detected:");
                selectedObject.Interact();       
            }

        }   
        // Get mouse release input (Left Click)
        if (Input.GetMouseButtonUp(0))
        {
            //ensure that the object has not been selected so as to not do too many raycasts
            if (selectedObject == null)
            {
                GetInteractible();
            }

            if (selectedObject != null)
            {
                //call the object's Interact method
                Debug.Log("Object Detected:");
                selectedObject.OneClickInteract();
            }

            selectedObject = null;

            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Cursor Unlocked");
        }
    }

    //gets the interactible object that the player has held/clicked
    private void GetInteractible()
    {
        //local variables for the clipping planes of the camera, and the raycast

        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        RaycastHit hit;

        //Get the worldpoint coordinates for the mouse input
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        
        //cast ray a ray to determine hit object
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear, Color.cyan);

        //get the interactible component of the object hit, and set it to the selected object
        selectedObject = hit.collider.gameObject.GetComponent<IInteractible>();
    }
}
