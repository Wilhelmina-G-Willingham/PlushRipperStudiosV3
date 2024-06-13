using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveAlongSeam : MonoBehaviour
{
    //reference to the seam track (Filled in-engine as there could be multiple seams on a single bear)
    public CreateSeamTrack Seam;

    //references to the current segment of the path, length of time between segments, and movement speed (higher is slower)
    private int currentSeg;
    private float transition;
    [SerializeField]
    private float moveSpeed = 2.5f;

    [SerializeField]
    private Material[] materials;
    private Renderer renderer;

    void Start()
    {
        //gets a random point along the seam to start at
        int startpoint = Random.Range(0, Seam.nodes.Length-1);
        
        //sets position to the determined point
        transform.position = Seam.nodes[startpoint].transform.position;
        currentSeg = startpoint;

        //fills the reference to the renderer component of this gameobject
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerStay(Collider other)
    {
        //return if the seam reference is not filled
        if (!Seam)
        {
            Debug.Log("NoSeamDetected");
            return;
        }

            //moves up the track with seamripper
            if (other.gameObject.CompareTag("SeamRipper"))
            {
            Debug.Log("SeamRipper Detected");
            //checks whether the current segment of the seam is the final (array is zero-based, .Length is not, hence Length -1)
                if (currentSeg == Seam.nodes.Length - 1)
                {
                //if seam is fully open, apply red material
                renderer.material = materials[0];
                return;
                }
                //if it has not reached the end of the track, move up
                else
                {
                //if mover is moving, apply white material
                renderer.material = materials[1];
                Move(moveSpeed);
                }
            }
            //moves down the track with sewing needle
            if (other.gameObject.CompareTag("SewingNeedle"))
            {
            Debug.Log("SewingNeedle Detected");
            if (currentSeg != -1)
                {
                    Move(-moveSpeed);
                renderer.material = materials[1];
                }
                else
                {
                //if seam is closed, apply green material
                renderer.material = materials[2];
                return;
                }
            }
    }
    //movement logic. Polarity is a positive/minus check 
    private void Move(float polarity)
    {
        //transition time divides against the polarity, to determine direction.
        transition += Time.deltaTime * 1 / polarity;
        
        //determines what segment is the current segment based on transition value
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
        //calls the lerp function in the seam's script
        transform.position = Seam.LinearPosition(currentSeg, transition);
    }
}
