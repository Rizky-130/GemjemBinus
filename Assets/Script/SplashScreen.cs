using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Animator transition;
    public float delayBeforeTransition = 4f;
    public DamageEffect damageEffect;

    public float transitionTime = 1f;
    public string nextSceneName;

    void Start()
    {
        StartCoroutine(AutoLoad());
    }
    void Update()
    {
        damageEffect.StartLowHealthEffect();
    }

    IEnumerator AutoLoad()
    {
        // tunggu sebelum mulai transition (biar warning kebaca dulu)
        yield return new WaitForSeconds(delayBeforeTransition);

        // trigger animasi fade out
        if (transition != null)
        {
            transition.SetTrigger("Close");
        }

        // tunggu animasi selesai
        yield return new WaitForSeconds(transitionTime);
        

        // pindah scene
        SceneManager.LoadScene(nextSceneName);
    }
}