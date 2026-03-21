using UnityEngine;
using UnityEngine.EventSystems;

public class ExitTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator exit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        exit.SetBool("IsHovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exit.SetBool("IsHovering", false);
    }
}