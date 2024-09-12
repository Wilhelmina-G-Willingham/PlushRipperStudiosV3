using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public static event System.Action<int> OnDisplayActivated;

    private void OnEnable()
    {
        // Example of triggering display activation
        // You might want to replace this with actual display detection logic
        if (OnDisplayActivated != null)
        {
            OnDisplayActivated.Invoke(1); // Trigger for display 1
        }
    }
}
