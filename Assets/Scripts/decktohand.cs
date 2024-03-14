using UnityEngine;
using UnityEngine.UI;

public class ButtonClickListener : MonoBehaviour
{
    public Deck deck;
    public GameObject cardPrefab;
    public Transform panelToSpawnCard;

    void Start()
    {
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


        GetComponent<Button>().onClick.AddListener(SpawnCard);
    }

    // Método que se llama cuando se hace clic en el botón
    void SpawnCard()
    {
        // Obtener una carta aleatoria del mazo
        Card randomCard = deck.GetRandomCard();

        if (randomCard != null)
        {

            GameObject newCard = Instantiate(cardPrefab, panelToSpawnCard);

        }
    }
}
