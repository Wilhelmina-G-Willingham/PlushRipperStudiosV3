using UnityEngine;

public class SeamRipperTool : MonoBehaviour
{
    public BoxCollider toolCollider;    // BoxCollider for the seam ripper tool
    public Transform marker;            // Marker on the bear's back seam
    public Transform toolTipPoint;      // A Transform point at the end of the seam ripper
    public float rotationSpeed = 5f;    // Speed at which the tool rotates to face the marker
    public float minimumDistance = 0.1f; // Minimum distance to prevent jitter when close to the marker
    public LayerMask toolLayerMask;     // Layer mask for detecting the tool
    public Vector3 rotationOffset;      // Offset for adjusting the rotation of the tool

    private bool isMouseHovering = false;
    private Quaternion initialRotation; // Store the initial rotation of the tool

    private void Start()
    {
        // Store the original orientation of the tool
        initialRotation = transform.rotation;

        // If no toolTipPoint is set manually, create one at the forward end of the BoxCollider
        if (toolTipPoint == null && toolCollider != null)
        {
            Vector3 toolEndPoint = toolCollider.center + new Vector3(0, 0, toolCollider.size.z / 2);
            GameObject tipPointObj = new GameObject("ToolTipPoint");
            tipPointObj.transform.SetParent(toolCollider.transform);
            tipPointObj.transform.localPosition = toolEndPoint;
            toolTipPoint = tipPointObj.transform;
        }
    }

    private void Update()
    {
        // Check if the mouse is hovering over the tool
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, toolLayerMask))
        {
            isMouseHovering = hit.collider == toolCollider;
        }
        else
        {
            isMouseHovering = false;
        }

        // If the mouse is hovering and the button is held down, rotate directly toward the marker with offset
        if (isMouseHovering && Input.GetMouseButton(0) && marker != null && toolTipPoint != null)
        {
            float distanceToMarker = Vector3.Distance(toolTipPoint.position, marker.position);

            if (distanceToMarker > minimumDistance)
            {
                Vector3 directionToMarker = (marker.position - toolTipPoint.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(directionToMarker, Vector3.up);

                // Apply the rotation offset
                targetRotation *= Quaternion.Euler(rotationOffset);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            // Smoothly return to the initial rotation when not hovering or mouse button not held
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

