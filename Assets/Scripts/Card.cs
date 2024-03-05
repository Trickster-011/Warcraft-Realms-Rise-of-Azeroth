using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
	public new string name;
	public string description;
	public Sprite artwork;
	public string tipCard;
	public int numSpecial;
	public int attack;
	public void Print()
	{
		Debug.Log(name + ": " + description + " The card tip: " + tipCard);
	}

}


