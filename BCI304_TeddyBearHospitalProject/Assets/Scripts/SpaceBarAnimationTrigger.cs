using UnityEngine;

public class SpaceBarAnimationTrigger : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string triggerName = "TriggerAnimation"; // Name of the trigger parameter

    private bool canPlayAnimation = false; // Flag to control animation playback

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set the flag to allow animation playback
            canPlayAnimation = true;
        }

        // Check if the flag is true and the Animator component is assigned
        if (canPlayAnimation && animator != null)
        {
            // Trigger the animation using the trigger parameter
            animator.SetTrigger(triggerName);
            // Reset the flag to prevent continuous playback
            canPlayAnimation = false;
        }
    }
}

