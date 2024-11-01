using UnityEngine;

public class BearStuffingController : MonoBehaviour
{
    public SkinnedMeshRenderer bearRenderer; // Renderer of the bear with blendshapes
    public string blendshapeName = "Emptiness"; // Name of the blendshape to control
    public GameObject[] stuffingPieces; // Array of stuffing models inside the bear (order from first to last piece)

    private int currentStuffingLevel; // Tracks the number of stuffing pieces currently in the bear

    void Start()
    {
        // Start with the bear fully stuffed (3 pieces)
        currentStuffingLevel = stuffingPieces.Length;
        SetBlendshapeValue();
        UpdateStuffingModels();
    }

    public void RemoveStuffing()
    {
        if (currentStuffingLevel > 0)
        {
            currentStuffingLevel--;
            SetBlendshapeValue();
            UpdateStuffingModels();
        }
    }

    public void AddStuffing()
    {
        if (currentStuffingLevel < stuffingPieces.Length)
        {
            currentStuffingLevel++;
            SetBlendshapeValue();
            UpdateStuffingModels();
        }
    }

    private void SetBlendshapeValue()
    {
        int blendshapeIndex = bearRenderer.sharedMesh.GetBlendShapeIndex(blendshapeName);
        if (blendshapeIndex >= 0)
        {
            // Map the current stuffing level to blendshape values: full (0) to empty (100)
            float blendshapeValue = (3 - currentStuffingLevel) * (100f / (stuffingPieces.Length - 1));
            bearRenderer.SetBlendShapeWeight(blendshapeIndex, blendshapeValue);
        }
    }

    private void UpdateStuffingModels()
    {
        // Enable/disable stuffing models based on current stuffing level
        for (int i = 0; i < stuffingPieces.Length; i++)
        {
            stuffingPieces[i].SetActive(i < currentStuffingLevel);
        }
    }
}

