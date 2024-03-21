using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int deckSize = 25; // Tamaño deseado del mazo
    public CardDatabase cardDatabase;
    public GameObject cardPrefab; // Prefab de la carta que quieres instanciar
    public Transform panelToSpawnCard; // Panel donde quieres instanciar la carta

    void Start()
    {
        if (cardDatabase != null)
        {
            // Verificar si el mazo tiene menos cartas que el tamaño deseado
            while (deck.Count < deckSize)
            {
                // Agregar una carta aleatoria al mazo
                var randomIndex = Random.Range(0, cardDatabase.cards.Count + 1);
                var randomCard = cardDatabase.cards[randomIndex];
                deck.Add(randomCard);
            }

            // Imprimir el tamaño de la lista de cartas antes de instanciarlas
            //Debug.Log("Tamaño del mazo: " + deck.Count);

            // Eliminar todas las cartas existentes en el panel antes de instanciar las nuevas
            foreach (Transform child in panelToSpawnCard)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            Debug.LogError("No se ha asignado una referencia a la base de datos de cartas en el script Deck.");
        }
    }

    // Método para obtener una carta aleatoria del mazo
    public Card GetRandomCard()
    {
        Shuffle(); // Mezcla el mazo antes de seleccionar una carta aleatoria

        if (deck.Count > 0)
        {
            var randomIndex = Random.Range(0, deck.Count + 1);
            return deck[randomIndex];
        }
        else
        {
            Debug.LogWarning("El mazo está vacío. No se puede obtener una carta aleatoria.");
            return null;
        }
    }

    public void Shuffle()
    {
        for (var i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
            deck.Add((Card)temp);
        }
    }
    public void RemoveCard(Card card)
    {
        deck.Remove(card);
    }
}