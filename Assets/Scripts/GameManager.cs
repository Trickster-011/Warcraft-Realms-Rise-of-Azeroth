using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        PREPARED, 
        PLAY, 
        GAMEOVER
    }
    private GameState Status;
    // Start is called before the first frame update
    void Start()
    {
        Status = GameState.PREPARED;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Status)
        {
            case GameState.PREPARED:
                break;
            case GameState.PLAY:
                break;
            case GameState.GAMEOVER:
                break;
        }
    }
}
