using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ToolMovement : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject parentLocation;

    [SerializeField]
    private float targetHeight = 6f;
    //when the object is held, move in relation to the mouse
    public void Interact()
    {
        Vector3 objectPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(this.transform.position).z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(objectPos);
        this.transform.position = new Vector3(worldPos.x, targetHeight, worldPos.z);
        
        Cursor.visible = false;
    }
    public void OneClickInteract()
    {
        this.transform.position = parentLocation.transform.position;
        Cursor.visible = true;
    }
}
