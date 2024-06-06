using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//allows the class to run in-editor, so that the gizmos are drawn in edit mode
[ExecuteInEditMode]
public class CreateSeamTrack : MonoBehaviour
{
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
        //store a node as the first position, and the next node in the array as the second
        Vector3 p1 = nodes[seg].position;
        Vector3 p2 = nodes[seg + 1].position;
       
        //lerp between the points
        return Vector3.Lerp(p1, p2, ratio);
    }

    //draw dotted lines between seams in sequence, to make it easier to see the path
    private void OnDrawGizmos()
    {
        for (int i = 0; i < nodes.Length-1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position, 3.0f);
        }
    }
}
