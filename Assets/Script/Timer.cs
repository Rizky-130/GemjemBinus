using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    public float timeLeft = 10f;
    public TextMesh timerText;
    public HealthPoint hp;

    bool isTimeUp = false;

    void Update()
    {
        if (!gameManager.gameStarted || isTimeUp)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isTimeUp = true;

            hp.Die();
        }

        timerText.text = Mathf.Ceil(timeLeft).ToString();
    }
}