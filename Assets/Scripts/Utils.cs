using UnityEngine;

public class Utils : MonoBehaviour
{
    void Start()
    {
        
    }
 

public int CantidadFila(Transform TransformActual)
{
        // Obtener el componente Transform del objeto actual
        int Cantidad = 0;
        // Iterar a trav�s de cada hijo del objeto actual
        foreach (Transform hijo in TransformActual)
        {
            // Acceder al hijo actual y hacer algo con �l
            Debug.Log("Nombre del hijo: " + hijo.name);
   
            // Si quieres hacer algo con el hijo, puedes agregar tu l�gica aqu�
       }

        return Cantidad;
}

}
