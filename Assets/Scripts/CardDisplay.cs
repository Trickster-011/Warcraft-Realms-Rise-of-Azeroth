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
	public Text attackText;
	void Start()
	{
		nameText.text = card.cardName;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artWorkFront;

		tipCardText.text = card.tipCard.ToString();
		attackText.text = card.attack.ToString();
	}
	public void DisplayCard(Card card)
	{

		// Mostrar la parte delantera o trasera de la carta según el valor booleano showFront
		artworkImage.sprite = card.showFront ? card.artWorkFront : card.artWorkBack;

		// Mostrar otros datos de la carta
		nameText.text = card.cardName;
		

		attackText.text = "Attack: " + card.attack.ToString();
	}
}

