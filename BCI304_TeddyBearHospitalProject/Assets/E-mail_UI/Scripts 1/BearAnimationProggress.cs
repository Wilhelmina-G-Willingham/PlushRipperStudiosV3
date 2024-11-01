using UnityEngine;

public class ZipperBlendshapeController : MonoBehaviour
{
    public GameObject bearModel;            // The bear model with blendshapes
    public SkinnedMeshRenderer bearRenderer; // SkinnedMeshRenderer component of the bear
    public int blendshapeIndex;             // The index of the blendshape you want to modify
    public Transform marker;                // The marker that moves along the back seam
    public Transform seamStart;             // Start position of the back seam
    public Transform seamEnd;               // End position of the back seam
    public Transform node2;                 // Node 2 position to check against

    private float maxDistance;              // Maximum distance of the seam for normalization

    // Reference to the Remove Stuffing button
    public GameObject removeStuffingButton; // Drag your button here in the inspector

    void Start()
    {
        if (bearRenderer == null)
        {
            bearRenderer = bearModel.GetComponent<SkinnedMeshRenderer>();
        }

        // Calculate the maximum distance between the start and end of the seam
        maxDistance = Vector3.Distance(seamStart.position, seamEnd.position);
        // Initially hide the button
        removeStuffingButton.SetActive(false);
    }

    void Update()
    {
        UpdateBlendshapeValue();
        CheckMarkerPosition(); // Check if the marker has reached Node 2
    }

    // Updates the blendshape value based on the marker's position along the seam
    void UpdateBlendshapeValue()
    {
        // Get the current distance of the marker from the start of the seam
        float currentDistance = Vector3.Distance(seamStart.position, marker.position);

        // Normalize the distance to a value between 0 and 100
        float blendshapeValue = Mathf.Clamp((currentDistance / maxDistance) * 100, 0, 100);

        // Set the blendshape value
        bearRenderer.SetBlendShapeWeight(blendshapeIndex, blendshapeValue);

        Debug.Log("Blendshape Value: " + blendshapeValue);
    }

    // Checks if the marker has reached Node 2 and shows the button accordingly
    void CheckMarkerPosition()
    {
        // Check if the marker's position is close to Node 2
        if (Vector3.Distance(marker.position, node2.position) < 0.1f) // Adjust threshold as necessary
        {
            removeStuffingButton.SetActive(true); // Show button when at Node 2
        }
        else
        {
            removeStuffingButton.SetActive(false); // Hide button otherwise
        }
    }

    // Method to set the blendshape to open or close the back seam
    public void ToggleBackSeam(bool isOpen)
    {
        if (isOpen)
        {
            marker.position = seamEnd.position; // Move marker to end to open seam
        }
        else
        {
            marker.position = seamStart.position; // Move marker to start to close seam
        }

        UpdateBlendshapeValue(); // Update the blendshape value after toggling
    }
}
