using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAnimationOnceOnEnable : MonoBehaviour
{
    public GameObject animationCanvas;        // The Canvas holding the animation
    public Animator animator;                 // The Animator component controlling the animation
    public string animationName;              // The name of the animation to play
    public GameObject textPopup;              // The Popup GameObject holding the text
    public Text hiddenText;                   // The Text component that will be revealed after the animation

    private bool animationPlayed = false;     // To ensure the animation is played only once

    private void OnEnable()
    {
        // Check if the animation has already been played in this session
        animationPlayed = PlayerPrefs.GetInt("AnimationPlayed", 0) == 1;

        // Hide the text at the start
        if (hiddenText != null)
        {
            hiddenText.gameObject.SetActive(false);
        }

        // If the animation hasn't been played yet, activate the canvas and play it
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

        // Wait for 1 frame to ensure the canvas is active
        yield return null;

        // Start the animation
        if (animator != null && !string.IsNullOrEmpty(animationName))
        {
            Debug.Log($"Playing Animation: {animationName}");
            animator.Play(animationName);
        }
        else
        {
            Debug.LogError("Animator or Animation Name is missing!");
        }
    }

    // Method to be called by the animation event to pause at the second last keyframe
    public void PauseAnimation()
    {
        if (animator != null)
        {
            animator.speed = 0f;  // Pause the animation
            Debug.Log("Animation Paused at the second last keyframe!");

            // Unhide the text after the animation pauses
            UnhideText();
        }
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

        // Remove the canvas hiding logic
        // Optionally, keep the animation canvas visible even after the animation plays once
    }
}
