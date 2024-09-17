using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject homeScreenPanel; // Assign the Home Screen panel in the Inspector
    public GameObject inboxPanel;
    public GameObject archivePanel;
    public GameObject binPanel;
    public GameObject additionalPanel; // Assign the new additional panel in the Inspector

    void Start()
    {
        ShowHomeScreen(); // Ensure the scene starts on the Home Screen panel
    }

    public void ShowHomeScreen()
    {
        homeScreenPanel.SetActive(true);
        inboxPanel.SetActive(false);
        archivePanel.SetActive(false);
        binPanel.SetActive(false);
        additionalPanel.SetActive(false);
    }

    public void ShowInbox()
    {
        homeScreenPanel.SetActive(false);
        inboxPanel.SetActive(true);
        archivePanel.SetActive(false);
        binPanel.SetActive(false);
        additionalPanel.SetActive(false);
    }

    public void ShowArchive()
    {
        homeScreenPanel.SetActive(false);
        inboxPanel.SetActive(false);
        archivePanel.SetActive(true);
        binPanel.SetActive(false);
        additionalPanel.SetActive(false);
    }

    public void ShowBin()
    {
        homeScreenPanel.SetActive(false);
        inboxPanel.SetActive(false);
        archivePanel.SetActive(false);
        binPanel.SetActive(true);
        additionalPanel.SetActive(false);
    }

    public void ShowAdditionalPanel()
    {
        homeScreenPanel.SetActive(false);
        inboxPanel.SetActive(false);
        archivePanel.SetActive(false);
        binPanel.SetActive(false);
        additionalPanel.SetActive(true);
    }
}
