using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
    //class currently not implemented - designed to create a timed mode for the original prototype
{
    public float timeElapsed = 0f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay(timeElapsed);
        }
    }

    void UpdateTimerDisplay(float currentTime)
    {
        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
        UpdateTimerDisplay(timeElapsed);
    }
}




