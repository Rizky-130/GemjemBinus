using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToOtherScene()
    {
        SceneManager.LoadScene("ComputerPOV");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Opening");
    }
    
    public void RetryScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}