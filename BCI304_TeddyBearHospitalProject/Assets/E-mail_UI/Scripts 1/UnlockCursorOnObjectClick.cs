using UnityEngine;

public class UnlockCursorOnObjectClick : MonoBehaviour
{
    public GameObject targetObject; // The object to be clicked on to unlock the cursor

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to detect clicks on the target object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == targetObject)
                {
                    UnlockAndShowCursor();
                }
            }
        }
    }

    private void UnlockAndShowCursor()
    {
        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("Cursor unlocked and visible after clicking on the object.");
    }
}
