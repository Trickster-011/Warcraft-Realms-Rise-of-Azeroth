using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
	public string cardName;
	public string description;
	public Sprite artWorkFront;
	public Sprite artWorkBack;
	public bool showFront;
	public string tipCard;
    public string tipForPrefab;
    public int id;
	public int attack;
	public int faction;
	public bool back;
	public void Print()

	{
		Debug.Log(cardName + ": " + description + " The card tip: " + tipCard);
	}
	public void ToggleSide()
	{
		showFront = !showFront;
	}
}



