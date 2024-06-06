using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerFunction : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject closedPos;
    [SerializeField]
    private GameObject openedPos;

    //vectors for the open and closed positions of the drawer
    private Vector3 closed;
    private Vector3 opened;
    public bool bDrawerOpen;

    [SerializeField]
    private AudioClip OpenSound;
    [SerializeField]
    private AudioClip CloseSound;

    //store the positions of the open and closed positions as vectors, so that each drawer in a set can use the same position objects
    private void Awake()
    {
        closed = new Vector3 (transform.position.x, transform.position.y, closedPos.transform.position.z);
        opened = new Vector3 (transform.position.x, transform.position.y, openedPos.transform.position.z);
    }
    public void OneClickInteract()
    {
        //check if the drawer is open or closed and call the appropriate function
        Debug.Log("RegisteredClick");
        if (bDrawerOpen == false)
        {
            DrawerOpen(); 
        }
        else
        {
            DrawerClose();
        }
    }
    private void DrawerClose()
    {
        //Close the Drawer
        Debug.Log("DrawerClosed");
        transform.position = closed;
        
        //toggle drawer state
        bDrawerOpen = false;
        //play the drawer open sound effect
        SoundFXManager.instance.PlaySoundFXClip(CloseSound, transform, 1f);
    }

    //repeat of above function, inversed. will be consolidated later with system managers and such
    private void DrawerOpen() 
    {
        //open the drawer
        Debug.Log("DrawerOpened");
        transform.position = opened;

        //toggle drawer state
        bDrawerOpen = true;

        //play the drawer open sound effect
        SoundFXManager.instance.PlaySoundFXClip(OpenSound, transform, 1f);
    }


}
