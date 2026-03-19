using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

 public void GoToOtherScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
