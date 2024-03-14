using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int deckSize;
    public CardDatabase cardDatabase;

    void Start()
    {
        deckSize = 25;
        if (cardDatabase != null)
        {
            for (int i = 0; i < deckSize; i++)
            {
                int randomIndex = Random.Range(0, cardDatabase.cards.Count);
                Card randomCard = cardDatabase.cards[randomIndex];
                deck.Add(randomCard);
            }
        }
        else
        {
            Debug.LogError("No se ha asignado una referencia a la base de datos de cartas en el script Deck.");
        }
    }

    void Update()
    {
        // No es necesario hacer nada en Update en este momento
    }
    public Card GetRandomCard()
    {
        if (deck.Count > 0)
        {
            int randomIndex = Random.Range(0, deck.Count);
            return deck[randomIndex];
        }
        else
        {
            Debug.LogWarning("El mazo está vacío. No se puede obtener una carta aleatoria.");
            return null;
        }
    }
}