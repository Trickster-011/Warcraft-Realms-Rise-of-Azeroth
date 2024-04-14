//using System;
using System.Collections.Generic;
using UnityEngine;
using static Dragable;
[System.Serializable]

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int deckSize = 26; // Tamaño deseado del mazo
    public CardDatabase cardDatabase;
    public GameObject especial; // Prefab de la carta que quieres instanciar
    public GameObject gold;
    public GameObject platine;
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
            foreach(Card card in cardDatabase.cards)
            {
            deck.Add(card);
            }
            
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
            Card card = deck[randomIndex];
            deck.RemoveAt(randomIndex);
            return card;
            
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
    public void SpawnCard()
    {
        // Verificar si el panel ya tiene 10 objetos hijos
        if (panelToSpawnCard.childCount >= 10)
        {
            Debug.Log("No se puede agregar más cartas. Límite alcanzado.");
            return;
        }
        if (deckSize<=0) 
        {
            Debug.Log("No Hay mas cartas");
            return;
        }
        // Obtener una carta aleatoria del mazo
        Card randomCard = GetRandomCard();

        if (randomCard != null)
        {
            
            Debug.Log(randomCard.ToString());

            // Determinar qué prefab usar según el tipo de carta
            GameObject cardPrefabToUse = null;
            switch (randomCard.tipForPrefab)
            {
                case "E":
                    cardPrefabToUse = especial;
                    break;
                case "G":
                    cardPrefabToUse = gold;
                    break;
                case "P":
                    cardPrefabToUse = platine;
                    break;
                // Agrega más casos según sea necesario para otros tipos de carta
                default:
                    Debug.LogWarning("Tipo de carta no reconocido para asignar un prefab: " + randomCard.tipForPrefab);
                    break;
            }
        
        if (cardPrefabToUse != null)
            {

                // Instanciar el prefab de la carta y colocarlo en el panel especificado
                GameObject newCardObject = Instantiate(cardPrefabToUse, panelToSpawnCard);
                
                // Obtener el componente CardDisplay del nuevo objeto de tarjeta
                CardDisplay newCardDisplay = newCardObject.GetComponent<CardDisplay>();
                // Obtener el componente Dragable del nuevo objeto de tarjeta
                //Dragable newDragable = newCardObject.GetComponent<Dragable>();
                // Asignar los datos del ScriptableObject de la carta al CardDisplay
                newCardObject.GetComponent<Dragable>().card = randomCard;
                switch (randomCard.tipCard)
                {
                    case "M":
                        newCardObject.GetComponent<Dragable>().TypeOfItem = Slot.MELEE;
                        break;
                    case "A":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.ASEDIO;
                        break;
                    case "R":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.RANGE;
                        break;
                    case "MA":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.MELEEASEDIO;
                        break;
                    case "RA":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.ASEDIORANGE;
                        break;
                    case "MRA":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.MELEEASEDIORANGE;
                        break;
                    case "C":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.CLIMA;
                        break;
                    case "AU":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.AUMENTO;
                        break;
                    case "E":
                        newCardDisplay.GetComponent<Dragable>().TypeOfItem = Slot.MELEEASEDIORANGE;
                        break;
                    // Agrega más casos según sea necesario para otros tipos de carta
                    default:
                        // Manejo de caso por defecto o lanzar una excepción si es necesario
                        Debug.LogWarning("Tipo de carta no reconocido: " + randomCard.tipCard);
                        break;
                }
                newCardDisplay.card = randomCard;
                newCardDisplay.DisplayCard();
                
                    }
                
                else
                {
                    Debug.LogError("No se pudo encontrar el componente Dragable en el prefab de la carta.");
                }
            }
            else
            {
                Debug.LogError("Prefab de carta no definido para el tipo de carta: " + randomCard.tipForPrefab);
            }
        }
     
    }
      
    


    