using UnityEngine;
using UnityEngine.UI;

public class CustomCursorHandler : MonoBehaviour
{
    public Texture2D defaultCursor;  // The default cursor sprite
    public Texture2D hoverCursor;    // The cursor sprite when hovering over a button
    public Vector2 cursorHotspot = Vector2.zero; // Cursor hotspot (set to the center of the cursor sprite)

    void Start()
    {
        // Set the initial cursor
        Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
    }

    public void OnButtonHover()
    {
        // Change the cursor to the hover sprite when hovering over a button
        Cursor.SetCursor(hoverCursor, cursorHotspot, CursorMode.Auto);
    }

    public void OnButtonExit()
    {
        // Change the cursor back to the default sprite when no longer hovering over a button
        Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
    }
}
