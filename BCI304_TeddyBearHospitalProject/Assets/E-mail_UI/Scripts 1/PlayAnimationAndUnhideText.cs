using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAnimationOnceOnSceneLoad : MonoBehaviour
{
    public GameObject animationCanvas;        // The Canvas holding the animation
    public Animator animator;                 // The Animator component controlling the animation
    public string animationName;              // The name of the animation to play
    public Text hiddenText;                   // The Text component that will be revealed after animation

    private bool animationPlayed = false;     // To ensure the animation is played only once

    private void Start()
    {
        // Check if the animation has already played in this session
        animationPlayed = PlayerPrefs.GetInt("AnimationPlayed", 0) == 1;

        // Hide the text at the start
        if (hiddenText != null)
        {
            hiddenText.gameObject.SetActive(false);
        }

        // If the animation has not been played yet, activate the canvas and play it
        if (!animationPlayed)
        {
            StartCoroutine(PlayAnimationAndUnhide());
        }
    }

    // Coroutine to play the animation and unhide the text
    private IEnumerator PlayAnimationAndUnhide()
    {
        // Activate the canvas holding the animation
        if (animationCanvas != null)
        {
            animationCanvas.SetActive(true);  // Ensure the animation canvas is visible
        }

        // Wait for 1 frame to ensure that the canvas becomes active
        yield return null;

        // Start the animation
        if (animator != null && !string.IsNullOrEmpty(animationName))
        {
            Debug.Log($"Playing Animation: {animationName}");
            animator.Play(animationName);
            yield return StartCoroutine(WaitForAnimationToEnd());
        }
        else
        {
            Debug.LogError("Animator or Animation Name is missing!");
        }
    }

    // Coroutine to wait until the animation finishes
    private IEnumerator WaitForAnimationToEnd()
    {
        yield return null; // Wait a frame to ensure animation state is updated

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Wait until the animation fully starts playing
        yield return new WaitUntil(() => stateInfo.IsName(animationName));
        Debug.Log("Animation Started!");

        // Wait until the animation is done playing (non-looping check)
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                                          !animator.IsInTransition(0));
        Debug.Log("Animation Ended!");

        // After the animation finishes, unhide the text
        UnhideText();
    }

    // Method to unhide the text
    private void UnhideText()
    {
        if (hiddenText != null)
        {
            hiddenText.gameObject.SetActive(true);  // Unhide the text
            Debug.Log("Text Unhidden!");
        }
        else
        {
            Debug.LogError("HiddenText reference is missing!");
        }

        // Mark the animation as played and save this state in PlayerPrefs
        animationPlayed = true;
        PlayerPrefs.SetInt("AnimationPlayed", 1);
        PlayerPrefs.Save();  // Save the preference so it persists

        // Optionally hide the animation canvas after the animation plays once
        if (animationCanvas != null)
        {
            animationCanvas.SetActive(false);
            Debug.Log("Animation Canvas Hidden!");
        }
    }
}
