using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class currently unused in present build. Code could be useful later though, perhaps to adapt into a deep clean mechanic?
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
        // Check if all objects with the "Dirt" tag are deleted
        if (GameObject.FindGameObjectsWithTag("Dirt").Length == 0)
        {
            // Change material to CleanMaterial
            if (materials.Length > 1) // Ensure there is a CleanMaterial
            {
                StartCoroutine(ChangeMaterialCoroutine(materials[1]));
            }
        }
    }

    // Coroutine for smooth material transition
    IEnumerator ChangeMaterialCoroutine(Material targetMaterial)
    {
        float elapsedTime = 0;
        Material startMaterial = rend.material;

        while (elapsedTime < lerpDuration)
        {
            rend.material.Lerp(startMaterial, targetMaterial, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rend.material = targetMaterial; // Ensure final material is set
    }
}

