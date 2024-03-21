using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "New Card Database", menuName = "Cards/Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<Card> cards = new List<Card>();

    public Card GetCardByName(string name)
    {
        return cards.FirstOrDefault(card => card.cardName == name);
    }
}