using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI meleeAttack;
    public TextMeshProUGUI rangedAttack;
    public TextMeshProUGUI asedioAttack;
    public TextMeshProUGUI totalAttack;
    public TextMeshProUGUI meleeAttack2;
    public TextMeshProUGUI rangedAttack2;
    public TextMeshProUGUI asedioAttack2;
    public TextMeshProUGUI totalAttack2;
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
   public RectTransform panelRectTransform;


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
        int MeleeAttack2 = int.Parse(meleeAttack2.text);
        int RangeAttack2 = int.Parse(rangedAttack2.text);
        int AsedioAttack2 = int.Parse(asedioAttack2.text);
        int TotalAttack2 = MeleeAttack2 + RangeAttack2 + AsedioAttack2;
        totalAttack2.text = TotalAttack2.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rotate();
        }
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
                Igual(id);
                break;
           case 7:
                Igual(id);
                break;
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
    public void Igual( int id)
    {
        //Debug.Log("igual");
        GameObject gameObject = meleeObject;
        int cant = 1;
        foreach (Transform childTransform in gameObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform == gameObject.transform)
            {
                continue; //saltar el objeto padre
            }
            if (childTransform.name.Contains("id"))
            {  
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero == id)
                    {
                        cant++;
                        Debug.Log(cant);
                    }    
                }
            }
        }
        bool flag = false;
        foreach (Transform childTransform in gameObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            
            if (childTransform == gameObject.transform)
            {
                continue; //saltar el objeto padre
            }
            if(flag == false)
            {
                if (childTransform.name.Contains("id"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero == id)
                        {
                            flag = true;
                           // Debug.Log("flag true");
                        }
                    }
                }
            }
            else if (flag == true)
            {
                //Debug.Log("igual");
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        numero *= cant;
                        textComponent.text = numero.ToString();
                       // Debug.Log("numero");
                        break;
                    }
                }
            }
            
        }
    }
    public void Rotate()
    {
      
      Vector3 rotationactual = panelRectTransform.localEulerAngles;
        rotationactual.z += 180;
        panelRectTransform.localEulerAngles = rotationactual; 
    }
}




