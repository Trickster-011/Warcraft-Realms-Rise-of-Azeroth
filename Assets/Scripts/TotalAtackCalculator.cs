using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalAttackCalculator : MonoBehaviour
{
    public Transform panelToCheck; // Referencia al panel cuyos hijos se van a verificar
    public TextMeshProUGUI totalAttackText; // Texto donde se mostrará el total de ataque

    void Update()
    {
        if (panelToCheck != null && totalAttackText != null)
        {
            int totalAttack = CalculateTotalAttack(panelToCheck);
            totalAttackText.text = totalAttack.ToString();
        }
        else
        {
            Debug.LogWarning("PanelToCheck o TotalAttackText no están asignados en el inspector.");
        }
    }

    int CalculateTotalAttack(Transform panel)
    {
        int totalAttack = 0;
        foreach (Transform child in panel)
        {
            // Verificar si el hijo tiene el componente que almacena el ataque
            var attackComponent = child.GetComponent<CardDisplay>();

            // Si el componente es nulo, continuar con el siguiente hijo
            if (attackComponent == null)
            {
                continue;
            }

            // Verificar si el campo attackText del componente es nulo
            if (attackComponent.attackText == null)
            {
                Debug.LogWarning("El campo attackText del componente CardDisplay es nulo en el objeto hijo: " + child.name);
                continue;
            }

            // Intentar convertir el texto del campo attackText a un entero
            int childAttack;
            if (!int.TryParse(attackComponent.attackText.text, out childAttack))
            {
                Debug.LogWarning("No se pudo convertir el texto del campo attackText a un entero en el objeto hijo: " + child.name);
                continue;
            }

            // Si todas las verificaciones pasan, sumar el ataque al total
            totalAttack += childAttack;
        }
        return totalAttack;
    }

}
