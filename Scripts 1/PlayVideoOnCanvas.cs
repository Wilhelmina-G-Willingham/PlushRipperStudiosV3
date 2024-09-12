using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnCanvas : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Assign the VideoPlayer in the Inspector

    private void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();  // Start playing the video when the script runs
        }
    }
}
