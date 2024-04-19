using System.Data;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool Hero1 = false;
    bool Hero2 = false;
    int lifePlayer = 2;
    int lifePlayer2 = 2;
    GameObject hero;
    GameObject hero2;
    public TextMeshProUGUI meleeAttack;
    public TextMeshProUGUI rangedAttack;
    public TextMeshProUGUI asedioAttack;
    public TextMeshProUGUI totalAttack;
    public TextMeshProUGUI meleeAttack2;
    public TextMeshProUGUI rangedAttack2;
    public TextMeshProUGUI asedioAttack2;
    public TextMeshProUGUI totalAttack2;
    public TextMeshProUGUI lifeP1;
    public TextMeshProUGUI lifeP2;
    public GameObject cardPrefab;
    public GameObject cardPrefab2;
    public GameObject cardPrefab3;
    public Card card;
    public Card card2;
    public Card card3;
    public Card card4;
    GameObject meleeObject;
    GameObject manonover;
    GameObject manonover2;
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
    GameObject clima;
    TurnSystem turn;
    public DisplayText textHide;
    public RectTransform panelRectTransform;

    void Start()
    {
        GameObject turnobject = GameObject.Find("TurnSystem");
        turn = turnobject.GetComponent<TurnSystem>();
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
        clima = GameObject.Find("clima");
        manonover = GameObject.Find("manonover");
        manonover2 = GameObject.Find("manonover2");
        hero = GameObject.Find("hero");
        hero2 = GameObject.Find("hero2");
        GameObject newCard = Instantiate(cardPrefab2, hero.GetComponent<Transform>());
        newCard.GetComponent<CardDisplay>().card = card3;
        newCard.GetComponent<CardDisplay>().DisplayCard();
        GameObject newCard2 = Instantiate(cardPrefab3, hero2.GetComponent<Transform>());
        newCard2.GetComponent<CardDisplay>().card = card4;
        newCard2.GetComponent<CardDisplay>().DisplayCard();
    }

    void Update()
    {
        lifeP1.text = "vidas "+lifePlayer.ToString();
        lifeP2.text = "vidas "+lifePlayer2.ToString();
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
        if (turn.isYourTurn == true)
        {
            manonover2.SetActive(true);
            manonover.SetActive(false);
        }
        else
        {
            manonover2.SetActive(false);
            manonover.SetActive(true);
        }
        if (turn.yourRound == true && turn.yourOponentRound == true)
        {
            if (TotalAttack > TotalAttack2)
            {
                Debug.Log("ganador1");
                textHide.textObject.text = "Ganador Player1";

                lifePlayer2--;
                turn.isYourTurn = true;
                Hero1 = false;
                Hero2 = false;
                Debug.Log(lifePlayer2);
                FinishRound();
            }
            else if (TotalAttack < TotalAttack2)
            {
                Debug.Log("ganador2");
                textHide.textObject.text = "Ganador Player2";
                lifePlayer--;
                turn.isYourTurn = false;
                Hero1 = false;
                Hero2 = false;
                Debug.Log(lifePlayer);
                FinishRound();
            }
            else
            {
                Debug.Log("empate");
                textHide.textObject.text = "Empate";
                lifePlayer--;
                lifePlayer2--;
                Hero1 = false;
                Hero2 = false;
                FinishRound();
            }
            turn.yourRound = false;
            turn.yourOponentRound = false;

        }


        if (lifePlayer <= 0)
        {
            Debug.Log("ganadorPlayer2");
            textHide.textObject.text = "Ganador Player2 Final";


            Invoke("action", 3f);
        }
        if (lifePlayer2 <= 0)
        {
            Debug.Log("ganadorPlayer1");
            textHide.textObject.text = "Ganador Player1 Final";


            Invoke("action", 3f);
        }
    }
   

     void action()
    {
        SceneManager.LoadScene("Gameover");
    }
    private void DisableAllObjects()
    {
        // Obtener todos los objetos de la escena
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Desactivar cada objeto
        foreach (GameObject obj in allObjects)
        {
            if (obj != gameObject && obj.name != "Camera") // No desactivar este objeto GameManager
            {
                obj.SetActive(false);
            }
        }
    }
    public void FinishRound()
    {
            Transform transform = meleeObject2.GetComponent<Transform>();
            int cantMelee2 = transform.childCount;
            transform = rangeObject2.GetComponent<Transform>();
            int cantRange2 = transform.childCount;
            transform = asedioObject2.GetComponent<Transform>();
            int cantAsedio2 = transform.childCount;
            transform = clima.GetComponent<Transform>();
            int cantClima = transform.childCount;
        transform = aumentoasedioObject.GetComponent<Transform>();
        if(transform.childCount>0) Destroy(transform.GetChild(0).gameObject);
        transform = aumentoasedioObject2.GetComponent<Transform>();
        if(transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        transform = aumentomeleeObject.GetComponent<Transform>();
        if(transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        transform = aumentomeleeObject2.GetComponent<Transform>();
        if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        transform = aumentorangeObject.GetComponent<Transform>();
        if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        transform = aumentorangeObject2.GetComponent<Transform>();
        if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        for (int i = 0; i < cantClima; ++i)
              {
                transform = clima.GetComponent<Transform>();
                GameObject hijoActual = transform.GetChild(i).gameObject;
                Destroy(hijoActual);
                }
                for (int i = 0; i < cantMelee2; ++i)
                {
                    transform = meleeObject2.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }
                for (int i = 0; i < cantRange2; ++i)
                {
                    transform = rangeObject2.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }
                for (int i = 0; i < cantAsedio2; ++i)
                {
                    transform = asedioObject2.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }     
            transform = meleeObject.GetComponent<Transform>();
            int cantMelee = transform.childCount;
            transform = rangeObject.GetComponent<Transform>();
            int cantRange = transform.childCount;
            transform = asedioObject.GetComponent<Transform>();
            int cantAsedio = transform.childCount;
                for (int i = 0; i < cantMelee; ++i)
                {
                    transform = meleeObject.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }
                for (int i = 0; i < cantRange; ++i)
                {
                    transform = rangeObject.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }  
                for (int i = 0; i < cantAsedio; ++i)
                {
                    transform = asedioObject.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
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
                Despeje();
                Despeje();
                break;
            case 19:
                Despeje();
                Despeje();
                break;
            case 4:
                Aumento(panel, 3);
                break;
            case 5:
                Clima(-3, id);
                break;
            case 6:
                Igual(id, 0);
                break;
           case 7:
                Igual(id, 0);
                break;
           case 8:
                break;
           case 9:
                break;
           case 10:
                Delete(0);
                break;
            case 11:
                Promedio();
                break;
            case 12:
                MaxDelete(0);
                break;
            case 13:
                MinDelete(0);
                break;
            case 14:
                Aumento(aumentomeleeObject.GetComponent<Transform>(), 3);
                break;
            case 15:
                GameObject newCard = Instantiate(cardPrefab, clima.GetComponent<Transform>());
                newCard.GetComponent<CardDisplay>().card = card;
                newCard.GetComponent<CardDisplay>().DisplayCard();
                break;
            case 16:
                Clima(-4, id);
                break;
            case 17:
                Clima(-2, id);
                break;
            case 18: 
                Aumento(panel, 3);
                break;
            case 28:
                Aumento(panel, 4);
                break;
            case 21:
                MinDelete(1);
                break;
            case 22:
                Igual(id, 1);
                break;
            case 26:
                Promedio();
                break;
            case 29:
                Aumento(aumentomeleeObject2.GetComponent<Transform>(), 3);
                break;
            case 20:
                Delete(1);
                break;
            case 23:
                MaxDelete(1);
                break;
            case 27:
                GameObject newCard2 = Instantiate(cardPrefab, clima.GetComponent<Transform>());
                newCard2.GetComponent<CardDisplay>().card = card2;
                newCard2.GetComponent<CardDisplay>().DisplayCard();
                break;
            case 30:
                break;
            case 31:
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
            case "aumentomelee2":
                aumentoIn = meleeObject2;
                break;
            case "aumentorange2":
                aumentoIn = rangeObject2;
                break;
            case "aumentoasedio2":
                aumentoIn = asedioObject2;
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
        GameObject aumentoIn2 = null;
        switch (id)
        {
            case 2:
                aumentoIn = meleeObject;
                aumentoIn2 = meleeObject2;
                break;
            case 5:
                aumentoIn = rangeObject;
                aumentoIn2 = rangeObject;
                break;
            case 16:
                aumentoIn = asedioObject;
                aumentoIn2 = asedioObject2;
                break;
            case 17:
                aumentoIn = meleeObject;
                aumentoIn2 = meleeObject2;
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
                    if(numeroActual < 0)numeroActual = 0;
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
        foreach (Transform childTransform in aumentoIn2.GetComponentsInChildren<Transform>(includeInactive: false))
        {
            if (childTransform == aumentoIn2.transform)
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
                    if (numeroActual < 0) numeroActual = 0;
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
    public void Igual( int id,int faction)
    {
        GameObject gameObject = null;
        if (faction == 0)
        { 
            gameObject = meleeObject;
        }
        else if (faction == 1) 
        {
           gameObject = meleeObject2;
        }
       int cant = 1;
        Transform trans = null; 
        foreach (Transform childTransform in gameObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform == gameObject.transform)
            {
                continue; //saltar el objeto padre
                
            }
            Debug.Log(childTransform.name);
            if (childTransform.name.Contains("id"))
            {
                
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                Debug.Log(textComponent);
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    
                    if (numero == id)
                    {
                        trans = childTransform.parent;
                        cant++;
                    }    
                }
            }
            
        }
        if(cant > 1)
        {  
        Debug.Log(trans.name);
        GameObject game = trans.gameObject;
        foreach (Transform childTransform in game.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if(childTransform == gameObject.transform)
            {
                continue;
            }
        if(childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if(textComponent != null)
                {
                    int numero = int.Parse (textComponent.text);
                    numero *= cant;
                    textComponent.text = numero.ToString();
                }
            }
        }
             }

    }
    public void Delete(int faction)
    {
        if(faction == 0)
        {     
       Transform transform = meleeObject2.GetComponent<Transform>();
       int cantMelee2 = transform.childCount;
       transform = rangeObject2.GetComponent<Transform>();
       int cantRange2 = transform.childCount;
       transform = asedioObject2.GetComponent<Transform>();
       int cantAsedio2 = transform.childCount;
        if(cantMelee2 <= cantRange2 && cantMelee2 <= cantAsedio2 && cantMelee2!=0)
        {
            for(int i = 0; i < cantMelee2; ++i)
            {
                transform = meleeObject2.GetComponent<Transform>();
                GameObject hijoActual = transform.GetChild(i).gameObject;
                Destroy(hijoActual);
            }
        }
        else if (cantRange2 <= cantAsedio2 && cantRange2 <= cantMelee2 && cantRange2!=0)
        {
            for (int i = 0; i < cantMelee2; ++i)
            {
                transform = rangeObject2.GetComponent<Transform>();
                GameObject hijoActual = transform.GetChild(i).gameObject;
                Destroy(hijoActual);
            }
        }
        else if(cantAsedio2 <= cantMelee2 && cantAsedio2 <= cantRange2 && cantAsedio2 != 0)
        {
            for (int i = 0; i < cantMelee2; ++i)
            {
                transform = asedioObject2.GetComponent<Transform>();
                GameObject hijoActual = transform.GetChild(i).gameObject;
                Destroy(hijoActual);
            }
        }
      }
    else if(faction == 1)
        {
            Transform transform = meleeObject.GetComponent<Transform>();
            int cantMelee = transform.childCount;
            transform = rangeObject.GetComponent<Transform>();
            int cantRange = transform.childCount;
            transform = asedioObject.GetComponent<Transform>();
            int cantAsedio = transform.childCount;
            if (cantMelee <= cantRange && cantMelee <= cantAsedio && cantMelee != 0)
            {
                for (int i = 0; i < cantMelee; ++i)
                {
                    transform = meleeObject.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }
            }
            else if (cantRange <= cantMelee && cantRange <= cantAsedio && cantRange != 0)
            {
                for (int i = 0; i < cantRange; ++i)
                {
                    transform = rangeObject.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }
            }
            else if (cantAsedio <= cantMelee && cantAsedio <= cantRange && cantAsedio != 0)
            {
                for (int i = 0; i < cantAsedio; ++i)
                {
                    transform = asedioObject.GetComponent<Transform>();
                    GameObject hijoActual = transform.GetChild(i).gameObject;
                    Destroy(hijoActual);
                }
            }
        }
    }
    public void Promedio()
    {
        Transform transform = meleeObject2.GetComponent<Transform>();
        int cantMelee2 = transform.childCount;
        transform = rangeObject2.GetComponent<Transform>();
        int cantRange2 = transform.childCount;
        transform = asedioObject2.GetComponent<Transform>();
        int cantAsedio2 = transform.childCount;
        transform = meleeObject.GetComponent<Transform>();
        int cantMelee = transform.childCount;
        transform = rangeObject.GetComponent<Transform>();
        int cantRange = transform.childCount;
        transform = asedioObject.GetComponent<Transform>();
        int cantAsedio = transform.childCount;
        int cantTotal = cantAsedio+cantAsedio2 + cantMelee + cantMelee2 + cantRange + cantRange2;
        int cant = (int.Parse(totalAttack.text) + int.Parse(totalAttack2.text)) % cantTotal;
        
        foreach (Transform childTransform in meleeObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero = cant;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in meleeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero = cant;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in asedioObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero = cant;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in asedioObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero = cant;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in rangeObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero = cant;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in rangeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero = cant;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
    }
    public void MaxDelete(int faction)
    {
        if(faction == 0)
        { 
        int max = 0;
        
        Transform transParent = null;
        foreach (Transform childTransform in rangeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero > max)
                    {
                        max = numero;
                        transParent = childTransform.parent;
                    }
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in meleeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero > max)
                    {
                        max = numero;
                        transParent = childTransform.parent;
                    }
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in asedioObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero > max)
                    {
                        max = numero;
                        transParent = childTransform.parent;
                    }
                    // Debug.Log("numero");
                    break;
                }
            }
        }

        
        if(transParent!= null)Destroy(transParent.gameObject);
             }
    else if(faction == 1)
        {
            int max = 0;

            Transform transParent = null;
            foreach (Transform childTransform in rangeObject.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero > max)
                        {
                            max = numero;
                            transParent = childTransform.parent;
                        }
                        // Debug.Log("numero");
                        break;
                    }
                }
            }
            foreach (Transform childTransform in meleeObject.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero > max)
                        {
                            max = numero;
                            transParent = childTransform.parent;
                        }
                        // Debug.Log("numero");
                        break;
                    }
                }
            }
            foreach (Transform childTransform in asedioObject.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero > max)
                        {
                            max = numero;
                            transParent = childTransform.parent;
                        }
                        // Debug.Log("numero");
                        break;
                    }
                }
            }


            if (transParent != null) Destroy(transParent.gameObject);
        }
    }
    public void Despeje()
    {
        Transform tranform =  clima.GetComponent<Transform>();
        int cant = tranform.childCount;
        for(int i = 0; i < cant; i++) 
        {
        Transform child = tranform.GetChild(i);
            Destroy(child.gameObject);
        }
    }
    public void MinDelete(int faction)
    {
        
        if(faction == 0)
        {
            int min = 999999;
            Transform transParent = null;
        foreach (Transform childTransform in rangeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero < min)
                    {
                        min = numero;
                        transParent = childTransform.parent;
                    }
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in meleeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero < min)
                    {
                        min = numero;
                        transParent = childTransform.parent;
                    }
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        foreach (Transform childTransform in asedioObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    if (numero < min)
                    {
                        min = numero;
                        transParent = childTransform.parent;
                    }
                    // Debug.Log("numero");
                    break;
                }
            }
        }
           if(transParent!= null) Destroy(transParent.gameObject);
     }
        else if(faction == 1)
        {
            int min = 999999;
            Transform transParent = null;
            foreach (Transform childTransform in rangeObject.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero < min)
                        {
                            min = numero;
                            transParent = childTransform.parent;
                        }
                        // Debug.Log("numero");
                        break;
                    }
                }
            }
            foreach (Transform childTransform in meleeObject.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero < min)
                        {
                            min = numero;
                            transParent = childTransform.parent;
                        }
                        // Debug.Log("numero");
                        break;
                    }
                }
            }
            foreach (Transform childTransform in asedioObject.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        int numero = int.Parse(textComponent.text);
                        if (numero < min)
                        {
                            min = numero;
                            transParent = childTransform.parent;
                        }
                        // Debug.Log("numero");
                        break;
                    }
                }
            }
            if (transParent != null) Destroy(transParent.gameObject);
        }
        
    }
    public void Check(Transform panel , GameObject obj)
    {
        GameObject aumento = null;
        switch (panel.name)
        {
            case "melee":
                aumento = aumentomeleeObject;
                break;
            case "melee2":
                aumento = aumentomeleeObject2;
                break;
            case "range":
                aumento = aumentorangeObject;
                break;
            case "range2":
                aumento = aumentorangeObject2;
                break;
            case "asedio":
                aumento = aumentoasedioObject;
                break;
            case "asedio2":
                aumento = aumentoasedioObject2;
                break;
        }
        Transform transform = aumento.GetComponent<Transform>();
        if (transform.childCount > 0)
        {
            int numero = 0;
            foreach (Transform childTransform in aumento.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("id"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        numero = int.Parse(textComponent.text);

                    }
                }
            }
            int cant = 0;
            switch(numero)
            {
                case 1:
                    cant = 1;
                    break;
                case 4:
                    cant = 3;
                    break;
                case 18:
                    cant = 3;
                    break;
                case 28:
                    cant = 4;
                    break;
            }
            foreach (Transform childTransform in obj.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        numero = int.Parse(textComponent.text);
                        numero += cant;
                        textComponent.text = numero.ToString();

                    }
                }
            }
        }
        if(clima.transform.childCount > 0) 
        {
            int numero = 0;
            foreach (Transform childTransform in clima.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("id"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        numero = int.Parse(textComponent.text);
                    }
                }
            }
            int cant = 0;
            
            switch (numero)
            {
                case 2:
                    if (panel.name ==  "melee" || panel.name == "melee2")cant = -2;
                    break;
                case 5:
                    if (panel.name == "range" || panel.name == "range2") cant = -3;
                    break;
                case 16:
                    if (panel.name == "asedio" || panel.name == "asedio2") cant = -4;
                    break;
                case 17:
                    if (panel.name == "melee" || panel.name == "melee2") cant = -2;
                    break;
            }
            foreach (Transform childTransform in obj.GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (childTransform.name.Contains("Attack"))
                {
                    UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                    if (textComponent != null)
                    {
                        numero = int.Parse(textComponent.text);
                        numero += cant;
                        if (numero < 0) numero = 0;
                        textComponent.text = numero.ToString();

                    }
                }
            }
        }
    }
    public void Lich ()
    {
        if (Hero1 == true) return;
        else {
            Rotate();
            turn.isYourTurn=false;
        
        foreach (Transform childTransform in meleeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero /=2;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
    
        foreach (Transform childTransform in asedioObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero /= 2;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        
        foreach (Transform childTransform in rangeObject2.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero /= 2;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        Hero1 = true;
         }
        }
    public void Varian()
    {
        if (Hero2 == true) return;
        else {
            Rotate();
            turn.isYourTurn = true;
        

        foreach (Transform childTransform in meleeObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero -= 4;
                    if(numero < 0) numero = 0;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }

        foreach (Transform childTransform in asedioObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero -= 4;
                    if (numero < 0) numero = 0;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }

        foreach (Transform childTransform in rangeObject.GetComponentsInChildren<Transform>(includeInactive: true))
        {
            if (childTransform.name.Contains("Attack"))
            {
                UnityEngine.UI.Text textComponent = childTransform.GetComponent<UnityEngine.UI.Text>();
                if (textComponent != null)
                {
                    int numero = int.Parse(textComponent.text);
                    numero -= 4;
                    if (numero < 0) numero = 0;
                    textComponent.text = numero.ToString();
                    // Debug.Log("numero");
                    break;
                }
            }
        }
        Hero2 = true;
             }
        }

    public void Rotate()
    {
      
      Vector3 rotationactual = panelRectTransform.localEulerAngles;
        rotationactual.z += 180;
        panelRectTransform.localEulerAngles = rotationactual; 
    }
}




