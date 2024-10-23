using UnityEngine;

public class SeamRipperTool : MonoBehaviour
{
    public BoxCollider toolCollider;  // BoxCollider for the seam ripper tool
    public Transform marker;          // Marker on the bear's back seam
    public Transform toolTipPoint;    // A Transform point at the end of the seam ripper (set in Inspector or automatically)

    private void Start()
    {
        // If no toolTipPoint is set manually, create one at the forward end of the BoxCollider
        if (toolTipPoint == null && toolCollider != null)
        {
            // Calculate the local forward end point of the BoxCollider
            Vector3 toolEndPoint = toolCollider.center + new Vector3(0, 0, toolCollider.size.z / 2);
            GameObject tipPointObj = new GameObject("ToolTipPoint");
            tipPointObj.transform.SetParent(toolCollider.transform);
            tipPointObj.transform.localPosition = toolEndPoint;
            toolTipPoint = tipPointObj.transform;
        }
    }

    private void Update()
    {
        if (marker != null && toolTipPoint != null)
        {
            // Make the seam ripper tool point towards the marker
            Vector3 directionToMarker = marker.position - toolTipPoint.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToMarker);
            transform.rotation = targetRotation;
        }
    }
}
