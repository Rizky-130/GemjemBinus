using UnityEngine;
using UnityEngine.EventSystems;

public class IconAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator Play;
    public AudioSource audioSource;
    public AudioClip hoverSound;

    private bool isHovering = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHovering) return;

        isHovering = true;

        Play.SetBool("Hover", true);

        if (audioSource != null && hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;

        Play.SetBool("Hover", false);
    }
}