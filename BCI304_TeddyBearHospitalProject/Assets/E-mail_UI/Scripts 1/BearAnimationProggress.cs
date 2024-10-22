using UnityEngine;

public class BearBackSeamController : MonoBehaviour
{
    public SkinnedMeshRenderer bearRenderer;  // The bear's SkinnedMeshRenderer
    public int backSeamBlendShapeIndex;       // The blendshape index for the back seam
    public Transform marker;                  // The marker on the bear's back seam
    public Transform seamStart;               // The starting point of the back seam
    public Transform seamEnd;                 // The ending point of the back seam

    private void Update()
    {
        // Calculate the normalized position of the marker between seamStart and seamEnd
        float seamLength = Vector3.Distance(seamStart.position, seamEnd.position);
        float markerPosition = Vector3.Distance(seamStart.position, marker.position);
        float normalizedPosition = Mathf.Clamp01(markerPosition / seamLength);

        // Update the back seam blendshape value based on the marker's position
        bearRenderer.SetBlendShapeWeight(backSeamBlendShapeIndex, normalizedPosition * 100f);
    }
}
