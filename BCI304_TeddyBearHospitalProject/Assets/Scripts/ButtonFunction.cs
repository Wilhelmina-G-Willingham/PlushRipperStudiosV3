using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    // Function to be called when the button is clicked
    public void LoadGreyboxTopDownCameraScene()
    {
        // Load the scene named "Greybox_TopDownCamera"
        SceneManager.LoadScene("Greybox_TopDownCamera");
    }


    private void Start()
    {

        Button button = GetComponent<Button>();


        button.onClick.AddListener(LoadGreyboxTopDownCameraScene);
    }
}





