using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this for UI elements

public class DrawerFunction : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject closedPos;
    [SerializeField]
    private GameObject openedPos;

    // Vectors for the open and closed positions of the drawer
    private Vector3 closed;
    private Vector3 opened;
    public bool bDrawerOpen;

    [SerializeField]
    private AudioClip OpenSound;
    [SerializeField]
    private AudioClip CloseSound;

    // Speed for opening and closing the drawer
    [SerializeField]
    private float openCloseSpeed = 1f; // Speed in units per second

    // Public reference for the Add Stuffing button
    public Button addStuffingButton; // Drag the Add Stuffing button here in the inspector

    private void Awake()
    {
        closed = new Vector3(transform.position.x, transform.position.y, closedPos.transform.position.z);
        opened = new Vector3(transform.position.x, transform.position.y, openedPos.transform.position.z);

        // Ensure the button is hidden at the start
        if (addStuffingButton != null)
        {
            addStuffingButton.gameObject.SetActive(false);
        }
    }

    public void OneClickInteract()
    {
        Debug.Log("RegisteredClick");
        if (bDrawerOpen == false)
        {
            StartCoroutine(DrawerOpen());
        }
        else
        {
            StartCoroutine(DrawerClose());
        }
    }

    private IEnumerator DrawerClose()
    {
        Debug.Log("DrawerClosed");
        Vector3 startingPos = transform.position;

        // Calculate the distance to cover
        float distance = Vector3.Distance(startingPos, closed);
        float journeyLength = distance / openCloseSpeed; // Total time to cover the distance
        float elapsedTime = 0f;

        while (elapsedTime < journeyLength)
        {
            transform.position = Vector3.Lerp(startingPos, closed, (elapsedTime / journeyLength));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.position = closed; // Ensure it ends exactly at closed position
        bDrawerOpen = false;
        SoundFXManager.instance.PlaySoundFXClip(CloseSound, transform, 1f);

        // Hide the button when the drawer is closed
        if (addStuffingButton != null)
        {
            addStuffingButton.gameObject.SetActive(false);
        }
    }

    private IEnumerator DrawerOpen()
    {
        Debug.Log("DrawerOpened");
        Vector3 startingPos = transform.position;

        // Calculate the distance to cover
        float distance = Vector3.Distance(startingPos, opened);
        float journeyLength = distance / openCloseSpeed; // Total time to cover the distance
        float elapsedTime = 0f;

        while (elapsedTime < journeyLength)
        {
            transform.position = Vector3.Lerp(startingPos, opened, (elapsedTime / journeyLength));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.position = opened; // Ensure it ends exactly at opened position
        bDrawerOpen = true;
        SoundFXManager.instance.PlaySoundFXClip(OpenSound, transform, 1f);

        // Show the button when the drawer is opened
        if (addStuffingButton != null)
        {
            addStuffingButton.gameObject.SetActive(true);
        }
    }
}
