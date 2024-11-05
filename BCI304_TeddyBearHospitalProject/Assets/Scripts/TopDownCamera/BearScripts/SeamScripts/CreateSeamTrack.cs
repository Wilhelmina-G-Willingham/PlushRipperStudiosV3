using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CreateSeamTrack : MonoBehaviour
{
    /// <summary>
    /// This class creates a linear track for the seam system, along which an object can be moved up or down, to keep track of how far open or closed the seam is. 
    /// This will later be tied into an animation, and allow/block access to the bear stuffing system (yet to be implemented).
    /// The track can be expanded in-engine by adding more nodes to the array.
    /// </summary>
    
    
    //an array of every node (corner) on the seam. This will allow the seam to wrap around the bear. Array is public as it is accessed by the mover script
    public Transform[] nodes;

    //array of audioclips to be fed to the sound effects manager
    public AudioClip[] sewingSounds;

    private void Start()
    {
        //Grab each child object and stores them in the array (Nodes can be added/removed manually in-editor)
        nodes = GetComponentsInChildren<Transform>();
    }

    //interpolates the position of a mover object between each node on the seam
    public Vector3 LinearPosition(int seg, float ratio)
    {
        //store a given node as the first position, and the next node in the array as the second
        Vector3 p1 = nodes[seg].position;
        Vector3 p2 = nodes[seg + 1].position;

        //lerp between the points
        return Vector3.Lerp(p1, p2, ratio);
    }

   
}
