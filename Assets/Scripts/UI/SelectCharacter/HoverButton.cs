using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform rectTransform;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //animator.Play("Hover Off");

    }
    public void OnPointerEnter(PointerEventData eventData)
    {        
        animator.Play("Hover On");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.Play("Hover Off");
    }
}
