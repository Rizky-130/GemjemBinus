using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject pathObject;
    public GameObject timerUI;

    public bool gameStarted = false;

    void Start()
    {
        // awal
        startUI.SetActive(true);
        pathObject.SetActive(false);
        timerUI.SetActive(false);
    }

    public void StartGame()
    {
        gameStarted = true;

        startUI.SetActive(false);
        pathObject.SetActive(true);
        timerUI.SetActive(true);
    }
}