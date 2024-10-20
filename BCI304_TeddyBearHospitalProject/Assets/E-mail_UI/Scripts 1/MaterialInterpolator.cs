using UnityEngine;

public class SinkAlphaFader : MonoBehaviour
{
    public GameObject bearObject;     // The bear whose material will be affected
    public GameObject sinkObject;     // The sink GameObject to detect when it's clicked
    public float fadeDuration = 2.0f; // Duration of the fade effect in seconds

    private Material bearMaterial;    // The material of the bear
    private bool isSinkActivated = false;  // To track if the sink has been activated
    private bool isFadingComplete = false; // To track if the fading process has completed
    private float fadeTimer = 0.0f;   // Timer for tracking fade progress

    private void Start()
    {
        // Get the material from the bearObject's renderer
        if (bearObject != null)
        {
            Renderer renderer = bearObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                bearMaterial = renderer.material;
            }
        }
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))  // Left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the sink object was clicked
                if (hit.collider.gameObject == sinkObject && !isFadingComplete)
                {
                    isSinkActivated = true;
                    fadeTimer = 0.0f; // Reset fade timer when the sink is activated
                }
            }
        }

        // If the sink is activated, start fading the bear material
        if (isSinkActivated && !isFadingComplete)
        {
            FadeAlphaOverTime();
        }
    }

    private void FadeAlphaOverTime()
    {
        if (bearMaterial != null)
        {
            // Gradually fade the alpha over time
            fadeTimer += Time.deltaTime;
            float alphaValue = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);

            // Apply the new alpha to the bear material's color
            Color color = bearMaterial.color;
            color.a = alphaValue;
            bearMaterial.color = color;

            // Stop the fading process once fully transparent and mark it as complete
            if (alphaValue <= 0)
            {
                isFadingComplete = true; // Mark the fade as complete
                isSinkActivated = false; // Deactivate the sink interaction
                color.a = 0f; // Ensure the alpha stays at 0
                bearMaterial.color = color;
            }
        }
    }
}

