using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

	public Card card;

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text tipCardText;
	public Text attackText;

	// Use this for initialization
	void Start()
	{
		nameText.text = card.name;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artwork;

		tipCardText.text = card.tipCard.ToString();
		attackText.text = card.attack.ToString();
	}

}
