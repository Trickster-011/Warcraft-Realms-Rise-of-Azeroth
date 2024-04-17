using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Dragable.Slot TypeOfItem;
    public GameManager game;
    public int limit;
    TurnSystem turn;

    private void Start()
    {
        GameObject turnobject = GameObject.Find("TurnSystem");
        turn = turnobject.GetComponent<TurnSystem>();
        // Buscar el objeto GameManager en la escena y asignarlo a la variable 'game'
        game = FindObjectOfType<GameManager>();

        // Verificar si se encontró el objeto GameManager
        if (game == null)
        {
            Debug.LogError("No se encontró el objeto GameManager en la escena.");
        }
    }
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
        if (d != null && !d.isBlocked)
        {
            Debug.Log("Draggable object detected: " + d.name);
            //Debug.Log("Card ID: " + d.card.id);
            // Verificar si el objeto padre ya tiene la cantidad máxima de hijos
            if (this.transform.childCount <= limit)
            {
                if (TypeOfItem == d.TypeOfItem)
                {
                    d.parentToReturnTo = this.transform;
                    Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                    game.Spell(d.card.id, this.transform);
                    game.Rotate();
                    d.BlockDragable();
                    if(turn.isYourTurn == true)turn.EndYourTurn();
                    else turn.EndYourOponentTurn();
                }
                else if (TypeOfItem == Dragable.Slot.MELEE)
                {
                    if (d.TypeOfItem == Dragable.Slot.MELEEASEDIO || d.TypeOfItem == Dragable.Slot.MELEEASEDIORANGE)
                    {
                        d.parentToReturnTo = this.transform;
                        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                        game.Spell(d.card.id, this.transform);
                        game.Rotate();
                        d.BlockDragable();
                        if (turn.isYourTurn == true) turn.EndYourTurn();
                        else turn.EndYourOponentTurn();
                    }
                }
                else if (TypeOfItem == Dragable.Slot.RANGE)
                {
                    if (d.TypeOfItem == Dragable.Slot.ASEDIORANGE || d.TypeOfItem == Dragable.Slot.MELEEASEDIORANGE)
                    {
                        d.parentToReturnTo = this.transform;
                        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                        game.Spell(d.card.id, this.transform);
                        game.Rotate();
                        d.BlockDragable();
                        if (turn.isYourTurn == true) turn.EndYourTurn();
                        else turn.EndYourOponentTurn();
                    }
                }
                else if (TypeOfItem == Dragable.Slot.ASEDIO)
                {
                    if (d.TypeOfItem == Dragable.Slot.ASEDIORANGE || d.TypeOfItem == Dragable.Slot.MELEEASEDIO || d.TypeOfItem == Dragable.Slot.MELEEASEDIORANGE)
                    {
                        d.parentToReturnTo = this.transform;
                        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
                        game.Spell(d.card.id, this.transform);
                        game.Rotate();
                        d.BlockDragable();
                        if (turn.isYourTurn == true) turn.EndYourTurn();
                        else turn.EndYourOponentTurn();


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
