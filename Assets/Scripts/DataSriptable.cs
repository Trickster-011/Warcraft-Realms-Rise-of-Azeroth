using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card Database", menuName = "Cards/Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<Card> cards = new List<Card>();

    public Card GetCardByName(string name)
    {
        foreach (Card card in cards)
        {
            if (card.Cardname == name)
            {
                return card;
            }
        }
        return null; // Si no se encuentra ninguna carta con el nombre dado
    }
}