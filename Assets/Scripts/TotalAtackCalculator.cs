using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalAttackCalculator : MonoBehaviour
{
    public Transform panelToCheck; // Referencia al panel cuyos hijos se van a verificar
    public TextMeshProUGUI totalAttackText; // Texto donde se mostrar� el total de ataque

    void Update()
    {
        if (panelToCheck != null && totalAttackText != null)
        {
            int totalAttack = CalculateTotalAttack(panelToCheck);
            totalAttackText.text = totalAttack.ToString();
        }
        else
        {
            Debug.LogWarning("PanelToCheck o TotalAttackText no est�n asignados en el inspector.");
        }
    }

    int CalculateTotalAttack(Transform panel)
    {
        int totalAttack = 0;
        foreach (Transform child in panel)
        {
            // Verificar si el hijo tiene el componente que almacena el ataque (ajusta esto seg�n tu implementaci�n)
            var attackComponent = child.GetComponent<CardDisplay>();

            // Si el hijo tiene el componente que almacena el ataque, sumar su valor al total
            if (attackComponent != null)
            {
                int childAttack = int.Parse(attackComponent.attackText.text);
                totalAttack += childAttack;
            }
        }
        return totalAttack;
    }
}
