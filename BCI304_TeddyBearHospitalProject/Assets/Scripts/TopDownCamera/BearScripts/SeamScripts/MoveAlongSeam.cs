using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveAlongSeam : MonoBehaviour
{
    /// <summary>
    /// Moves an object along the seam track, created in the CreateSeamTrack Class. The track moves up or down
    /// </summary>

    // Reference to the seam track (Filled in-engine as there could be multiple seams on a single bear)
    public CreateSeamTrack Seam;

    // References to the current segment of the path, length of time between segments, and movement speed (higher is slower)
    private int currentSeg;
    private float transition;
    [SerializeField]
    private float moveSpeed = 2.5f;

    [SerializeField]
    private Material[] materials;

    // Renamed from 'renderer' to 'objectRenderer' to avoid name conflict
    private Renderer objectRenderer;

    void Start()
    {
        // Gets a random point along the seam to start at
        int startpoint = Random.Range(0, Seam.nodes.Length - 1);

        // Sets position to the determined point
        transform.position = Seam.nodes[startpoint].transform.position;
        currentSeg = startpoint;

        // Fills the reference to the renderer component of this GameObject
        objectRenderer = GetComponent<Renderer>();
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
            // Checks whether the current segment of the seam is the final (array is zero-based, .Length is not, hence Length -1)
            if (currentSeg == Seam.nodes.Length - 1)
            {
                // If seam is fully open, apply red material
                objectRenderer.material = materials[0];
                return;
            }
            // If it has not reached the end of the track, move up
            else
            {
                // If mover is moving, apply white material
                objectRenderer.material = materials[1];
                Move(moveSpeed);
            }
        }

        // Moves down the track with sewing needle
        if (other.gameObject.CompareTag("SewingNeedle"))
        {
            Debug.Log("SewingNeedle Detected");
            if (currentSeg != -1)
            {
                Move(-moveSpeed);
                objectRenderer.material = materials[1];
            }
            else
            {
                // If seam is closed, apply green material
                objectRenderer.material = materials[2];
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
}



