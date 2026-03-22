using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTransition : MonoBehaviour
{
    public Animator animator;
    public string animationName = "IconTransition";
    public float animationDuration = 1f;
    public string sceneToLoad;

    public void OnButtonPressed()
    {
        StartCoroutine(PlayAndLoad());
    }

    IEnumerator PlayAndLoad()
    {
        animator.Play(animationName);

        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene(sceneToLoad);
    }
}