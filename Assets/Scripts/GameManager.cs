using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI meleeAttack;
    public TextMeshProUGUI rangedAttack;
    public TextMeshProUGUI asedioAttack;
    public TextMeshProUGUI totalAttack;
    
    void Start()
    {
        
    }
    void Update()
    {
        int MeleeAttack = int.Parse(meleeAttack.text);
        int RangeAttack = int.Parse(rangedAttack.text);
        int AsedioAttack = int.Parse(asedioAttack.text);
        int TotalAttack = MeleeAttack + RangeAttack + AsedioAttack;
        totalAttack.text = TotalAttack.ToString() ;
    }
}
