using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public void Close()
    {
        // Close the popup by deactivating it
        gameObject.SetActive(false);
    }
}
