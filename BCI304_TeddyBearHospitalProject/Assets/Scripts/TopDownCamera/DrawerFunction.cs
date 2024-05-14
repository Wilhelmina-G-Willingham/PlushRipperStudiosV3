using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerFunction : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject closedPos;
    [SerializeField]
    private GameObject openedPos;

    [SerializeField]
    private AudioClip[] clip;
    
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private float timescale = 1f;
    private bool bDrawerOpen = false;

    public void OneClickInteract()
    {

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
        //lerp between open and closed points - ask Arden for help with making it smooth
        Debug.Log("DrawerClosed");
        transform.position = Vector3.Lerp(transform.position, closedPos.transform.position, timescale);
        //toggle drawer state
        SoundSelect(1);
        bDrawerOpen = false;
    }

    //repeat of above function, inversed. will be consolidated later with system managers and such
    private void DrawerOpen() 
    {
        Debug.Log("DrawerOpened");
        transform.position = Vector3.Lerp(transform.position, openedPos.transform.position, timescale);
        SoundSelect(0);
        bDrawerOpen = true;
    }

    private void SoundSelect(int SoundClip)
    {
        AudioClip audioclip = clip[SoundClip];
        audio.PlayOneShot(audioclip);
    }
}
