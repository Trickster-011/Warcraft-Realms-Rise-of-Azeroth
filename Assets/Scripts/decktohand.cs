using UnityEngine;
using UnityEngine.UI;

public class ButtonClickListener : MonoBehaviour
{
    public Deck deck; // Referencia al script Deck
    public GameObject cardPrefab; // Prefab de la carta que quieres instanciar
    public Transform panelToSpawnCard; // Panel donde quieres instanciar la carta

    void Start()
    {
        // Asegúrate de que se haya asignado una referencia al script Deck y al panel
        if (deck == null)
        {
            Debug.LogError("No se ha asignado una referencia al script Deck en el editor de Unity.");
            return;
        }
        if (panelToSpawnCard == null)
        {
            Debug.LogError("No se ha asignado una referencia al panel en el editor de Unity.");
            return;
        }

        // Agrega un Listener al botón para que llame al método SpawnCard() cuando se haga clic en él
        GetComponent<Button>().onClick.AddListener(SpawnCard);
    }

    // Método que se llama cuando se hace clic en el botón
    void SpawnCard()
    {
        // Obtener una carta aleatoria del mazo
        Card randomCard = deck.GetRandomCard();

        if (randomCard != null)
        {
            // Instanciar el prefab de la carta y colocarlo en el panel especificado
            GameObject newCard = Instantiate(cardPrefab, panelToSpawnCard);
            // Configurar la visualización de la carta con los datos de randomCard
            // Por ejemplo, podrías tener un componente CardDisplay que maneje la visualización de la carta
            newCard.GetComponent<CardDisplay>().DisplayCard(randomCard);
            deck.RemoveCard(randomCard);
        }
    }
}