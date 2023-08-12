using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public abstract class ButtonHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] protected float hoverScaleFactor = 1.2f;

    Vector3 originalScale;
    protected bool isSelect;



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelect)
            return;
        Scale();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelect)
            return;
        Lessen();
    }




    private void Start() => originalScale = transform.localScale;
    protected void Scale() => transform.localScale = originalScale * hoverScaleFactor;
    protected void Lessen() => transform.localScale = originalScale;



}
