using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public Sprite normalSprite;  // The default sprite
    public Sprite clickedSprite; // The sprite to switch to when clicked

    private Image imageComponent;

    void Start()
    {
        // Get the Image component attached to this GameObject
        imageComponent = GetComponent<Image>();

        // Set the default sprite
        if (imageComponent != null && normalSprite != null)
        {
            imageComponent.sprite = normalSprite;
        }
    }

    public void OnClickChangeSprite()
    {
        // Switch to the clicked sprite
        if (imageComponent != null && clickedSprite != null)
        {
            imageComponent.sprite = clickedSprite;
        }
    }
}
