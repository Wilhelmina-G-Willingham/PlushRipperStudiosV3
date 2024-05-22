using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerFunction : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject closedPos;
    [SerializeField]
    private GameObject openedPos;

  
    private bool bDrawerOpen = false;

    public void OneClickInteract()
    {
        //check if the drawer is open or closed and call the appropriate function
        Debug.Log("RegisteredClick");
        if (bDrawerOpen == true)
        {
            DrawerClose();
        }
        else
        { 
            DrawerOpen();
        }
    }
    private void DrawerClose()
    {
        //lerp between open and closed points
        Debug.Log("DrawerClosed");
        transform.position = closedPos.transform.position;
        //toggle drawer state
        bDrawerOpen = false;
    }

    //repeat of above function, inversed. will be consolidated later with system managers and such
    private void DrawerOpen() 
    {
        Debug.Log("DrawerOpened");
        transform.position = openedPos.transform.position;
        bDrawerOpen = true;
    }


}
