using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDB : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    void Awake()
    {
        //cardhero
        cardList.Add(
            new Card
            {
                cardName = "Lich King",
                description = "El rey de la plaga, capaz de congelar a un enemigo por turno reduciendo su poder a la mitdad",
                artWorkFront = Resources.Load<Sprite>("The_Lich_King_TCG"),
                artWorkBack = Resources.Load<Sprite>("back"),
                tipCard = "H",
                id = 0,
                attack = 0,
                faction = 0
            });
        //cardspecial
        /*cardList.Add(new Card("Cinto de Pociones", "Aumenta en 1 el poder", Resources.Load<Sprite>("potionbelt"), "AU", 1, 1, 0));
        cardList.Add(new Card("Camara Helada", "Congela todas las unidades cuerpo a cuerpo y asedio disminuyendo su ataque en 2", Resources.Load<Sprite>("coldstorage"), "C", 2, 0, 0));
        cardList.Add(new Card("Reemplazo", "Toma el lugar de una carta aliada en el campo", Resources.Load<Sprite>("Target_Dummy_full"), "E", 3, 0, 0));
        cardList.Add(new Card("Sangre Vampirica", "Aumenta el poder de todas las cartas en la fila de Melee en 2", Resources.Load<Sprite>("Vampiric_Blood_full"), "AU", 4, 2, 0));
        cardList.Add(new Card("Vuelo Bronce", "El vuelo bronce crea un clima que disminuye todo el poder de las cartas de rango en 3 punto", Resources.Load<Sprite>("flight"), "C", 5, 3, 0));
        //cardgold        
        cardList.Add(new Card("Caballero Profano", "Multiplica su poder por la cantidad de caballeros profanos en el campo", Resources.Load<Sprite>("profano"), "M", 6, 4, 0));
        cardList.Add(new Card("Caballero De Sangre", "Multiplica su poder por la cantidad de caballeros de sangre en el campo", Resources.Load<Sprite>("blood-death-knight-by-me-v0-nfa5e3hd5rua1"), "M", 7, 5, 0));
        cardList.Add(new Card("Exiliado", "Su habilidad permite robar 1 carta del rival", Resources.Load<Sprite>("Wretched_Exile_full"), "M", 8, 3, 0));
        cardList.Add(new Card("Sirvienta del mago", "Calcula el poder promedio en el campo e iguala el poder de todos a este", Resources.Load<Sprite>("magister"), "MA", 11, 4, 0));
        cardList.Add(new Card("Picadora de Carne", "Elimina todos los enemigos de la fila con menos cantidad", Resources.Load<Sprite>("Meat_Grinder_full"), "A", 10, 4, 0));
        cardList.Add(new Card("Sirvienta del mago", "Calcula el poder promedio en el campo e iguala el poder de todos a este", Resources.Load<Sprite>("magister"), "MA", 11, 4, 0));
        cardList.Add(new Card("Caballero Profano", "Multiplica su poder por la cantidad de caballeros profanos en el campo", Resources.Load<Sprite>("profano"), "M", 16, 4, 0));
        cardList.Add(new Card("Caballero Profano", "Multiplica su poder por la cantidad de caballeros profanos en el campo", Resources.Load<Sprite>("profano"), "M", 17, 4, 0));
        cardList.Add(new Card("Caballero De Sangre", "Multiplica su poder por la cantidad de caballeros de sangre en el campo", Resources.Load<Sprite>("blood-death-knight-by-me-v0-nfa5e3hd5rua1"), "M", 18, 5, 0));
        cardList.Add(new Card("Caballero De Sangre", "Multiplica su poder por la cantidad de caballeros de sangre en el campo", Resources.Load<Sprite>("blood-death-knight-by-me-v0-nfa5e3hd5rua1"), "M", 19, 5, 0));
        cardList.Add(new Card("Exiliado", "Su habilidad permite robar 1 carta del rival", Resources.Load<Sprite>("Wretched_Exile_full"), "M", 20, 3, 0));
        cardList.Add(new Card("Exiliado", "Su habilidad permite robar 1 carta del rival", Resources.Load<Sprite>("Wretched_Exile_full"), "M", 21, 3, 0));
        cardList.Add(new Card("Nécrofago", "esbirro de la plaga", Resources.Load<Sprite>("Walking_Dead_full"), "M", 22, 2, 0));
        cardList.Add(new Card("Picadora de Carne", "Elimina todos los enemigos de la fila con menos cantidad", Resources.Load<Sprite>("Meat_Grinder_full"), "A", 23, 4, 0));
        cardList.Add(new Card("Sirvienta del mago", "Calcula el poder promedio en el campo e iguala el poder de todos a este", Resources.Load<Sprite>("magister"), "MA", 24, 4, 0));
        cardList.Add(new Card("Exiliado", "Su habilidad permite robar 1 carta del rival", Resources.Load<Sprite>("Wretched_Exile_full"), "M", 25, 3, 0));
        //cardsilver
        cardList.Add(new Card("Devoralmas", "Su habilidad elimina la carta más poderosa del campo enemigo", Resources.Load<Sprite>("Devourer_of_Souls_full"), "MRA", 12, 7, 0));
        cardList.Add(new Card("Gárgola", "Elimina la carta con menos poder del rival", Resources.Load<Sprite>("death_knight_minion___gargoyle_by_forrestimel_danbv98-fullview"), "R", 13, 7, 0));
        cardList.Add(new Card("Sindragosa", "Posee la habilidad de poner Camara helada en el campo", Resources.Load<Sprite>("Frost_Queen_Sindragosa_full"), "RA", 14, 8, 0));
        cardList.Add(new Card("Invencible", "Aumenta el poder en 3 de todas las cartas en su fila", Resources.Load<Sprite>("Invincible_full"), "M", 15, 5, 0));
*/
    }
}

