using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
	public string Cardname;
	public string description;
	public Sprite artworkFront;
	public Sprite artworkBack;
	public bool showFront;
	public string tipCard;
	public int id;
	public int attack;
	public int faction;
	public bool back;
	public void Print()

	{
		Debug.Log(Cardname + ": " + description + " The card tip: " + tipCard);
	}
	public void ToggleSide()
	{
		showFront = !showFront;
	}
}



