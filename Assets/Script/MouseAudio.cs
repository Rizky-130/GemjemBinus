using UnityEngine;

public class MouseClickSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            PlayClick();
        }
    }

    void PlayClick()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}