using UnityEngine;

public class CycleMaterials : MonoBehaviour
{
    public Material[] materials; // Array of materials to cycle through
    private int currentMaterialIndex = 0; // Current material index
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Set the initial material if materials array is not empty
        if (materials.Length > 0)
        {
            ApplyMaterial(materials[currentMaterialIndex]);
        }
        else
        {
            Debug.LogWarning("Materials array is empty. Please assign materials in the inspector.");
        }
    }

    void Update()
    {
        // Check if the D key is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Check if materials array is not empty
            if (materials.Length > 0)
            {
                // Increment the material index
                currentMaterialIndex++;

                // Loop back to the first material if the index exceeds the length of the array
                if (currentMaterialIndex >= materials.Length)
                {
                    currentMaterialIndex = 0;
                }

                // Apply the new material
                ApplyMaterial(materials[currentMaterialIndex]);
            }
            else
            {
                Debug.LogWarning("Materials array is empty. Please assign materials in the inspector.");
            }
        }
    }

    void ApplyMaterial(Material mat)
    {
        // Create a copy of the material to avoid modifying the original
        Material newMaterial = new Material(mat);

        if (newMaterial.HasProperty("_OverlayColor"))
        {
            // Apply overlay color if the property exists
            Color overlayColor = newMaterial.GetColor("_OverlayColor");
            newMaterial.SetColor("_OverlayColor", overlayColor);
            Debug.Log("Setting overlay color to: " + overlayColor);
        }
        else
        {
            Debug.Log("Material " + newMaterial.name + " does not have an _OverlayColor property. Applying material without changes.");
        }

        // Assign the new material to the renderer
        objectRenderer.material = newMaterial;
    }
}













