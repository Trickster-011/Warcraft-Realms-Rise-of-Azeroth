using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI meleeAttack;
    public TextMeshProUGUI rangedAttack;
    public TextMeshProUGUI asedioAttack;
    public TextMeshProUGUI totalAttack;

    GameObject meleeObject;
    GameObject meleeObject2;
    GameObject rangeObject;
    GameObject rangeObject2;
    GameObject asedioObject;
    GameObject asedioObject2;
    GameObject aumentomeleeObject;
    GameObject aumentomeleeObject2;
    GameObject aumentorangeObject;
    GameObject aumentorangeObject2;
    GameObject aumentoasedioObject;
    GameObject aumentoasedioObject2;

    void Start()
    {

        meleeObject = GameObject.Find("melee");
        meleeObject2 = GameObject.Find("melee2");
        rangeObject = GameObject.Find("rango");
        rangeObject2 = GameObject.Find("rango2");
        asedioObject = GameObject.Find("asedio");
        asedioObject2 = GameObject.Find("asedio2");
        aumentomeleeObject = GameObject.Find("aumentomelee");
        aumentomeleeObject2 = GameObject.Find("aumentomelee2");
        aumentorangeObject = GameObject.Find("aumentorange");
        aumentorangeObject2 = GameObject.Find("aumentorange2");
        aumentoasedioObject = GameObject.Find("aumentoasedio");
        aumentoasedioObject2 = GameObject.Find("aumentoasedio2");
    }

    void Update()
    {
        int MeleeAttack = int.Parse(meleeAttack.text);
        int RangeAttack = int.Parse(rangedAttack.text);
        int AsedioAttack = int.Parse(asedioAttack.text);
        int TotalAttack = MeleeAttack + RangeAttack + AsedioAttack;
        totalAttack.text = TotalAttack.ToString();
    }
    public void Spell(int id,Transform panel)
    {
        Debug.Log("Spell method called with id: " + id + ", panel: " + panel.name);
        switch (id)
        {
            case 1:
                Aumento(panel,1);
                //Debug.Log(panel.name);
                break;
            case 2:
                Clima(-2,id);
                //Debug.Log(panel.name);
                break;
            case 3:
                Aumento(panel, 0);
                break;
            case 4:
                Aumento(panel, 3);
                break;
            case 5:
                Clima(-3, id);
                break;
            case 6:
                Igual(panel, id);
                break;
                
                case 7:
                case 8:
                case 9:
                case 10:
                break;
        }
    }
    public void Aumento(Transform aumento , int cant)
    {
        GameObject aumentoIn = null;
        switch(aumento.name)
        {
            case "aumentomelee":
                aumentoIn = meleeObject;
                break;
            case "aumentorange":
                aumentoIn = rangeObject;
                break;
            case "aumentoasedio":
                aumentoIn = asedioObject;
                break;
        }
        Debug.Log(aumentoIn.name);
        foreach (Transform childTransform in aumentoIn.GetComponentsInChildren<Transform>(includeInactive: false))  
        {
            if (childTransform == aumentoIn.transform)
            {
                continue; // Saltar el objeto padre (melee)
            }

            // Verificar si el nombre del objeto hijo contiene "Attack"
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    // Modificar el valor del texto
                    int numeroActual = int.Parse(textComponent.text);
                    numeroActual += cant;
                    Debug.Log(numeroActual);
                    textComponent.text = numeroActual.ToString();
                    Debug.Log("Se aumentó el valor de Text del objeto hijo: " + childTransform.name);
                }
                else
                {
                    Debug.Log("El objeto hijo " + childTransform.name + " no tiene el componente Text.");
                }
            }
        }
    }
    public void Clima(int cant, int id)
    {
        GameObject aumentoIn = null;
        switch (id)
        {
            case 2:
                aumentoIn = meleeObject;
                break;
            case 5:
                aumentoIn = rangeObject;
                break;
        }
        //Debug.Log(aumentoIn.name);
        foreach (Transform childTransform in aumentoIn.GetComponentsInChildren<Transform>(includeInactive: false))
        {
            if (childTransform == aumentoIn.transform)
            {
                continue; // Saltar el objeto padre (melee)
            }

            // Verificar si el nombre del objeto hijo contiene "Attack"
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    // Modificar el valor del texto
                    int numeroActual = int.Parse(textComponent.text);
                    numeroActual += cant;
                    Debug.Log(numeroActual);
                    textComponent.text = numeroActual.ToString();
                    Debug.Log("Se aumentó el valor de Text del objeto hijo: " + childTransform.name);
                }
                else
                {
                    Debug.Log("El objeto hijo " + childTransform.name + " no tiene el componente Text.");
                }
            }
        }
    }
    public void Igual(Transform panel, int id)
    {
        
    }




}
