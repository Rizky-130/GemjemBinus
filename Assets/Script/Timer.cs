using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    public float timeLeft = 10f;
    public TextMesh timerText;

    void Update()
    {
        if (!gameManager.gameStarted)
            return;

        timeLeft -= Time.deltaTime;

        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            Debug.Log("WAKTU HABIS!");
        }
    }
}