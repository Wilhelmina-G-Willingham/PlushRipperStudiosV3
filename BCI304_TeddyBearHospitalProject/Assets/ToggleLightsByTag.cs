using System.Collections;  // This is required for IEnumerator and coroutines
using UnityEngine;

public class ToggleLightsByTag : MonoBehaviour
{
    public float toggleInterval = 1.0f;

    private GameObject[] purpleLights;  
    private GameObject[] yellowLights;  

    private bool isPurpleOn = true;    

    void Start()
    {
        purpleLights = GameObject.FindGameObjectsWithTag("Purple");
        yellowLights = GameObject.FindGameObjectsWithTag("Yellow");

        StartCoroutine(ToggleLights());
    }

    IEnumerator ToggleLights()
    {
        while (true)
        {
            
            isPurpleOn = !isPurpleOn;

            // Toggle purple lights
            foreach (GameObject purpleLight in purpleLights)
            {
                if (purpleLight.TryGetComponent<Light>(out Light lightComponent))
                {
                    lightComponent.enabled = isPurpleOn;
                }
            }

            
            foreach (GameObject yellowLight in yellowLights)
            {
                if (yellowLight.TryGetComponent<Light>(out Light lightComponent))
                {
                    lightComponent.enabled = !isPurpleOn;
                }
            }

            // Wait for the specified interval before toggling again
            yield return new WaitForSeconds(toggleInterval);
        }
    }

    public void SetToggleInterval(float newInterval)
    {
        toggleInterval = newInterval;
    }
}


