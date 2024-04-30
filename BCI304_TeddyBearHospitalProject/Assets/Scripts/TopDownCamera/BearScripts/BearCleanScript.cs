using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCleanScript : MonoBehaviour
{
    //an array of materials that the class can call
    [SerializeField]
    private Material[] materials;
    private Renderer rend;

    float lerpDuration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //fill reference to the object 
        rend = this.GetComponent<Renderer>();
        
        //use Dirty Material At Start
        if (rend != null && materials != null)
        { 
        rend.material = materials[0];
        }
    }

    // Update is called once per frame
        void Update()
        {

        }   
}
