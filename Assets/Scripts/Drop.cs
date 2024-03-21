using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot TypeOfItem = Dragable.Slot.MELEE;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
        {
            return;
        }
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
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
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            if (TypeOfItem == d.TypeOfItem)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
