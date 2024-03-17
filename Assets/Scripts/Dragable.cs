using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Runtime.ExceptionServices;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject hoverPanel; // Referencia al panel donde se mostrará la carta más grande

    public Transform parentToReturnTo = null;

    public Transform placeholderParent = null;

    public GameObject placeholder = null;
    public enum Slot { MELEE, ASEDIO, RANGE, AUMENTO, CLIMA };
    public Slot TypeOfItem = Slot.MELEE;
    void Star()
    {
        hoverPanel = GameObject.Find("Hover");

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject hoverCard = Instantiate(this.gameObject, hoverPanel.transform);
        hoverCard.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); // Ajusta el valor según sea necesario
        hoverCard.SetActive(true);

        // Calcula la posición central del panel de hover
        RectTransform panelRect = hoverPanel.GetComponent<RectTransform>();
        Vector3 panelCenter = panelRect.position + new Vector3(panelRect.rect.width / 2, panelRect.rect.height / 2, 0);

        // Ajusta la posición de la carta más grande para que se alinee con el centro del panel
        hoverCard.transform.position = panelCenter;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;
        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);
        int newSibiligIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSibiligIndex = i;
                if (placeholder.transform.GetSiblingIndex() < newSibiligIndex)
                    newSibiligIndex--;
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSibiligIndex);
    }
    public void OnEndDrag(PointerEventData eventData)

    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
        foreach (Transform child in hoverPanel.transform)
        {
            if (child.gameObject.name == this.gameObject.name)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }
}
