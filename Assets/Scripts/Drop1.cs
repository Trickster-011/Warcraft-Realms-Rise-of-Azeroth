using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot TypeOfItem = Dragable.Slot.MELEE;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        var d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            // Verificar si el objeto padre ya tiene la cantidad máxima de hijos
            if (this.transform.childCount <= 1)
            {
                if (TypeOfItem == d.TypeOfItem)
                {
                    d.parentToReturnTo = this.transform;
                    Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                }
            }
            else
            {
                Debug.Log("No se puede soltar más objetos. Límite alcanzado.");
            }
        }
    }
}