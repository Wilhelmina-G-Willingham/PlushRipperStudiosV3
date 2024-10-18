using UnityEngine;
using System.Collections;

public class MaterialChanger : MonoBehaviour
{
    public Material targetMaterial;         // The material to change to
    public float transitionDuration = 2f;   // Duration of the material transition
    private Material originalMaterial;      // The original material of the object
    private Renderer objectRenderer;        // The object's renderer
    private bool isChanging = false;        // Check if the material is changing

    private void Start()
    {
        // Get the object's renderer and save its original material
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    public void ActivateSink()
    {
        if (!isChanging && targetMaterial != null)
        {
            StartCoroutine(ChangeMaterial());
        }
    }

    private IEnumerator ChangeMaterial()
    {
        isChanging = true;
        float elapsedTime = 0f;

        // Cache initial values from the original material
        Color initialAlbedo = objectRenderer.material.GetColor("_Color");
        float initialMetallic = objectRenderer.material.GetFloat("_Metallic");
        Texture initialNormalMap = objectRenderer.material.GetTexture("_BumpMap");

        // Cache target values from the target material
        Color targetAlbedo = targetMaterial.GetColor("_Color");
        float targetMetallic = targetMaterial.GetFloat("_Metallic");
        Texture targetNormalMap = targetMaterial.GetTexture("_BumpMap");

        // Gradually interpolate between the original and target material properties
        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;

            // Lerp the Albedo (color)
            objectRenderer.material.SetColor("_Color", Color.Lerp(initialAlbedo, targetAlbedo, t));

            // Lerp the Metallic property
            objectRenderer.material.SetFloat("_Metallic", Mathf.Lerp(initialMetallic, targetMetallic, t));

            // Blend the normal map
            objectRenderer.material.SetTexture("_BumpMap", targetNormalMap);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final material properties are fully set
        objectRenderer.material.SetColor("_Color", targetAlbedo);
        objectRenderer.material.SetFloat("_Metallic", targetMetallic);
        objectRenderer.material.SetTexture("_BumpMap", targetNormalMap);

        isChanging = false;
    }
}

