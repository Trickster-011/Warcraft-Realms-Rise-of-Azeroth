using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int deckSize = 26; // Tamaño deseado del mazo
    public CardDatabase cardDatabase;
    public GameObject cardPrefab; // Prefab de la carta que quieres instanciar
    public Transform panelToSpawnCard; // Panel donde quieres instanciar la carta

    void Start()
    {
        if (cardDatabase != null)
        {
            // Verificar si hay suficientes cartas disponibles en la base de datos
            if (cardDatabase.cards.Count < deckSize)
            {
                Debug.LogError("No hay suficientes cartas en la base de datos para construir el mazo.");
                return;
            }

            // Verificar si el panel de spawn de cartas está asignado
            if (panelToSpawnCard == null)
            {
                Debug.LogError("No se ha asignado una referencia al panel en el editor de Unity.");
                return;
            }

            // Construir el mazo
            BuildDeck();
        }
        else
        {
            Debug.LogError("No se ha asignado una referencia a la base de datos de cartas en el script Deck.");
        }
    }

    // Método para construir el mazo
    void BuildDeck()
    {
        // Limpiar el mazo antes de construirlo
        deck.Clear();

        // Añadir cartas aleatorias desde la base de datos al mazo
        while (deck.Count < deckSize)
        {
            // Seleccionar una carta aleatoria desde la base de datos
            int randomIndex = Random.Range(0, cardDatabase.cards.Count);
            Card randomCard = cardDatabase.cards[randomIndex];

            // Añadir la carta al mazo
            deck.Add(randomCard);
        }

        // Mezclar el mazo después de construirlo
        Shuffle();
    }

    // Método para mezclar el mazo
    void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    // Método para obtener una carta aleatoria del mazo
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

    // Método para remover una carta del mazo
    public void RemoveCard(Card card)
    {
        deck.Remove(card);
    }
}