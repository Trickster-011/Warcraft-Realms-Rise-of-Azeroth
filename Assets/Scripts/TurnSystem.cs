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
    public bool yourRound;
    public bool yorOponentRound;
    
    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
        {
           
        }
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
