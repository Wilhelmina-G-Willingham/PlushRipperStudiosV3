using UnityEngine;

public class UnhideModelOnButtonPress : MonoBehaviour
{
    public GameObject modelToUnhide; // The model you want to unhide

    // Function to unhide the model
    public void UnhideModel()
    {
        if (modelToUnhide != null)
        {
            modelToUnhide.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No model assigned to unhide.");
        }
    }
}
