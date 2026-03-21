using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // waktu per level (detik)
    float currentTime;
    public TextMesh timerText;

    public bool isRunning = true;

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        timerText.text = Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
            TimeUp();
        }
    }

    void TimeUp()
    {
        isRunning = false;
        Debug.Log("WAKTU HABIS!");
        // TODO: game over / restart
    }

    public float GetTime()
    {
        return currentTime;
    }
}