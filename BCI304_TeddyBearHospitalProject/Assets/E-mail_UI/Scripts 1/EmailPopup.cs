using UnityEngine;
using UnityEngine.UI;

public class EmailPopup : MonoBehaviour
{
    [SerializeField] private Image emailImage; // Reference to the Image component that will display the asset

    public void SetEmailAsset(Sprite emailAsset)
    {
        if (emailImage != null)
        {
            emailImage.sprite = emailAsset; // Set the sprite of the image
            emailImage.SetNativeSize(); // Optionally adjust the size of the image to its native size
        }
        else
        {
            Debug.LogError("emailImage is not assigned.");
        }
    }
}
