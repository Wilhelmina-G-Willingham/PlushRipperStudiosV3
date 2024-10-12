using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnhideTextAfterParentVisible : MonoBehaviour
{
    public Text textToUnhide; // The Text component to be unhidden
    private bool isParentVisible; // To check if the parent is visible

    private void Start()
    {
        // Ensure the text is hidden at the start
        if (textToUnhide != null)
        {
            textToUnhide.gameObject.SetActive(false);
        }

        // Check if the parent is active
        isParentVisible = transform.parent != null && transform.parent.gameObject.activeSelf;
    }

    private void Update()
    {
        // Check if the parent is now visible
        if (!isParentVisible && transform.parent != null && transform.parent.gameObject.activeSelf)
        {
            isParentVisible = true; // Update the visibility status

            // Start coroutine to unhide the text after a delay
            StartCoroutine(UnhideTextAfterDelay(0.5f));
        }
    }

    private IEnumerator UnhideTextAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Unhide the text
        if (textToUnhide != null)
        {
            textToUnhide.gameObject.SetActive(true);
            Debug.Log("Text unhidden after parent became visible!");
        }
    }
}
