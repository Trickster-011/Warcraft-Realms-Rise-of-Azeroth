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
		nameText.text = card.Cardname;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artworkFront;

		tipCardText.text = card.tipCard.ToString();
		attackText.text = card.attack.ToString();
	}
	public void DisplayCard(Card card)
	{
		// Mostrar la parte delantera o trasera de la carta según el valor booleano showFront
		if (card.showFront)
		{
			artworkImage.sprite = card.artworkFront;
		}
		else
		{
			artworkImage.sprite = card.artworkBack;
		}

		// Mostrar otros datos de la carta
		nameText.text = card.Cardname;
		attackText.text = "Attack: " + card.attack.ToString();
	}
}

