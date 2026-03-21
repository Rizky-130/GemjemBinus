using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator Back;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Back.SetBool("Hovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Back.SetBool("Hovering", false);
    }
}