using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // For IPointerEnterHandler and IPointerExitHandler

public class SpriteChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image targetImage; // The Image component whose sprite will be changed
    [SerializeField] private Sprite normalSprite; // The sprite to show when not hovered
    [SerializeField] private Sprite hoverSprite;  // The sprite to show when hovered

    // Method called when the pointer enters the UI element
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null && hoverSprite != null)
        {
            targetImage.sprite = hoverSprite; // Change to the hover sprite
        }
    }

    // Method called when the pointer exits the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetImage != null && normalSprite != null)
        {
            targetImage.sprite = normalSprite; // Change back to the normal sprite
        }
    }

    public void SetSprite(Sprite newSprite)
    {
        targetImage.sprite = newSprite;
        targetImage.SetNativeSize(); // This sets the RectTransform to match the sprite's size
    }

}
