using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int yourOppositeTurn;
    public bool yourRound;
    public bool yourOponentRound;
    public GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void EndYourRound()
    {
        yourRound = true;
        isYourTurn = false;
        game.Rotate();
    }
    public void EndYourOponentRound()
    {
        yourOponentRound= true;
        isYourTurn = true;
        game.Rotate();
    }
    public void EndYourTurn()
    {
       isYourTurn = false;
    }
    public void EndYourOponentTurn()
    {
        isYourTurn = true;
    }
}
