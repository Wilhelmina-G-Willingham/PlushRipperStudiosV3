using UnityEngine;

public class LeHaloBrightnessLOL : MonoBehaviour
{
    [Range(0, 10)]
    public float haloBrightness = 1f; // Control halo brightness
    private Material haloMaterial;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            haloMaterial = renderer.material;
            haloMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void Update()
    {
        if (haloMaterial != null)
        {
            Color emissionColor = Color.white * haloBrightness;
            haloMaterial.SetColor("_EmissionColor", emissionColor);
        }
    }
}



