using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int yourOppositeTurn;
    public TextMeshProUGUI turnText;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        yourOppositeTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Turn Player 1";
        }else turnText.text = "Turn Player 2";
    }
    public void EndYourTurn()
    {
        isYourTurn = false;
        yourOppositeTurn += 1;
        turnText.text = "Turn Player 2";
    }
    public void EndYourOponentTurn()
    {
        turnText.text = "Turn Player 1";
        isYourTurn = true;
        yourTurn += 1;
    }
}
