using System.Collections;
using UnityEngine;

public class MoveAlongSeam : MonoBehaviour
{
    // Reference to the seam track (Filled in-engine as there could be multiple seams on a single bear)
    public CreateSeamTrack Seam;

    // References to the current segment of the path, length of time between segments, and movement speed (higher is slower)
    private int currentSeg;
    private float transition;
    [SerializeField]
    private float moveSpeed = 2.5f;

    [SerializeField]
    private Material[] materials;

    // Audio components for SeamRipper
    public AudioClip[] seamRipperClips;       // Array of audio clips for SeamRipper
    public AudioSource[] seamRipperSources;   // Array of audio sources for SeamRipper

    // Audio components for SewingNeedle
    public AudioClip[] sewingNeedleClips;     // Array of audio clips for SewingNeedle
    public AudioSource[] sewingNeedleSources; // Array of audio sources for SewingNeedle

    private bool isAudioPlaying = false; // Track if an audio clip is currently playing

    // Renamed from 'renderer' to 'objectRenderer' to avoid name conflict
    private SpriteRenderer objectRenderer;

    void Start()
    {
        // Gets a random point along the seam to start at
        int startpoint = Random.Range(0, Seam.nodes.Length - 1);

        // Sets position to the determined point
        transform.position = Seam.nodes[startpoint].transform.position;
        currentSeg = startpoint;

        // Fills the reference to the renderer component of this GameObject
        objectRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        // Return if the seam reference is not filled
        if (!Seam)
        {
            Debug.Log("NoSeamDetected");
            return;
        }

        // Moves up the track with seamripper
        if (other.gameObject.CompareTag("SeamRipper"))
        {
            Debug.Log("SeamRipper Detected");

            // Play a random seam ripper sound if no audio is currently playing
            if (!isAudioPlaying)
            {
                PlayRandomSound(seamRipperClips, seamRipperSources);
            }

            // Checks whether the current segment of the seam is the final (array is zero-based, .Length is not, hence Length -1)
            if (currentSeg == Seam.nodes.Length - 1)
            {
                // If seam is fully open, apply red material
                objectRenderer.color = Color.red;
                return;
            }
            else
            {
                // If mover is moving, apply white material
                objectRenderer.color = Color.white;
                Move(moveSpeed);
            }
        }

        // Moves down the track with sewing needle
        if (other.gameObject.CompareTag("SewingNeedle"))
        {
            Debug.Log("SewingNeedle Detected");

            // Play a random sewing needle sound if no audio is currently playing
            if (!isAudioPlaying)
            {
                PlayRandomSound(sewingNeedleClips, sewingNeedleSources);
            }

            if (currentSeg != -1)
            {
                Move(-moveSpeed);
                objectRenderer.color = Color.white;
            }
            else
            {
                // If seam is closed, apply green material
                objectRenderer.color = Color.green;
                return;
            }
        }
    }

    // Movement logic. Polarity is a positive/minus check 
    private void Move(float polarity)
    {
        // Transition time divides against the polarity, to determine direction.
        transition += Time.deltaTime * 1 / polarity;

        // Determines what segment is the current segment based on transition value
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
        }
        else if (transition < 0)
        {
            transition = 1;
            currentSeg--;
        }

        // Calls the lerp function in the seam's script
        transform.position = Seam.LinearPosition(currentSeg, transition);
    }

    // Method to play a random audio clip from a provided array of clips and sources
    private void PlayRandomSound(AudioClip[] clips, AudioSource[] sources)
    {
        if (clips.Length > 0 && sources.Length > 0)
        {
            // Select a random clip and audio source
            int randomClipIndex = Random.Range(0, clips.Length);
            int randomSourceIndex = Random.Range(0, sources.Length);

            AudioClip randomClip = clips[randomClipIndex];
            AudioSource randomSource = sources[randomSourceIndex];

            if (randomSource != null && randomClip != null)
            {
                // Only play the sound if the audio source is not currently playing
                if (!randomSource.isPlaying)
                {
                    randomSource.PlayOneShot(randomClip);
                    StartCoroutine(WaitForAudioToFinish(randomClip.length)); // Wait for the audio to finish
                }
            }
        }
        else
        {
            Debug.LogWarning("No audio clips or sources available to play!");
        }
    }
    private void Update()
    {
        objectRenderer.transform.rotation = Camera.main.transform.rotation;
    }

    // Coroutine to wait for the audio to finish playing
    private IEnumerator WaitForAudioToFinish(float clipDuration)
    {
        isAudioPlaying = true;
        yield return new WaitForSeconds(clipDuration); // Wait for the clip's duration
        isAudioPlaying = false;
    }
}
