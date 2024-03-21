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
<<<<<<< HEAD

            // Imprimir el tamaño de la lista de cartas antes de instanciarlas
            //Debug.Log("Tamaño del mazo: " + deck.Count);

            // Eliminar todas las cartas existentes en el panel antes de instanciar las nuevas
            foreach (Transform child in panelToSpawnCard)
            {
                Destroy(child.gameObject);
            }
=======
>>>>>>> parent of 94496979 (v0.7)
        }
        else
        {
            Debug.LogError("No se ha asignado una referencia a la base de datos de cartas en el script Deck.");
        }
    }

<<<<<<< HEAD
    // Método para obtener una carta aleatoria del mazo
=======
    void Update()
    {
        // No es necesario hacer nada en Update en este momento
    }
>>>>>>> parent of 94496979 (v0.7)
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
<<<<<<< HEAD

    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
    public void RemoveCard(Card card)
    {
        deck.Remove(card);
    }
=======
>>>>>>> parent of 94496979 (v0.7)
}