using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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

// public void EnterGame()
//     {
//         SceneManager.LoadScene("ComputerPOV");
//     }

public void ExitGame()
    {
        Application.Quit();
    }

}
