using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
	public Card card;
	public int id;
	public Text nameText;
	public Text descriptionText;
	public Image artworkImage;
	public Text tipCardText;
    public Text tipForPrefab;
    public Text attackText;
     void Star()
    {
        DisplayCard();
    }
    public void DisplayCard()
	{

		// Mostrar la parte delantera o trasera de la carta según el valor booleano showFront
		artworkImage.sprite = card.showFront ? card.artWorkFront : card.artWorkBack;

        // Mostrar otros datos de la carta
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        id = card.id;
        artworkImage.sprite = card.artWorkFront;
        tipCardText.text = card.tipCard.ToString();
        tipForPrefab.text = card.tipForPrefab.ToString();
        attackText.text =  card.attack.ToString();
	}
}

