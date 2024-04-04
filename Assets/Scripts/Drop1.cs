using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot TypeOfItem;

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
                else if (TypeOfItem == Dragable.Slot.MELEE)
                {
                    if( d.TypeOfItem == Dragable.Slot.MELEEASEDIO || d.TypeOfItem == Dragable.Slot.MELEEASEDIORANGE){
                        d.parentToReturnTo = this.transform;
                        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                    }
                else if(TypeOfItem == Dragable.Slot.RANGE)
                        if ( d.TypeOfItem == Dragable.Slot.ASEDIORANGE || d.TypeOfItem == Dragable.Slot.MELEEASEDIORANGE)
                        {
                            d.parentToReturnTo = this.transform;
                            Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                        }
                }
                else if (TypeOfItem == Dragable.Slot.ASEDIO)
                {
                    if ( d.TypeOfItem == Dragable.Slot.ASEDIORANGE || d.TypeOfItem == Dragable.Slot.MELEEASEDIORANGE)
                    {
                        d.parentToReturnTo = this.transform;
                        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                    }
                }

            }
            else
            {
                Debug.Log("No se puede soltar más objetos. Límite alcanzado.");
            }
        }
    }
}