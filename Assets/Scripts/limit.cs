using UnityEngine;

public class LimitChildren : MonoBehaviour
{
    public int maxChildren = 10; // Límite de objetos hijos

    public void AddChild(GameObject childPrefab)
    {
        // Contar los objetos hijos actuales
        var currentChildrenCount = transform.childCount;

        // Solo instanciar un nuevo objeto si no se ha alcanzado el límite
        if (currentChildrenCount < maxChildren)
        {
            Instantiate(childPrefab, transform.position, transform.rotation, transform);
        }
        else
        {
            Debug.Log("No se puede agregar más objetos. Límite alcanzado.");
        }
    }
}
