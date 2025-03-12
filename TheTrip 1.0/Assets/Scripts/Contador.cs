using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esto si usas UI de Unity

public class ItemCollector : MonoBehaviour
{
    public int itemCount = 0; // Contador de objetos
    public Text Contadorhongo; // Referencia al texto del HUD

    void Start()
    {
        UpdateContadorhongo();                  //l inicio
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que se ha recogido tiene la etiqueta "Item"
        if (other.CompareTag("Item"))
        {
            itemCount++; // Incrementa el contador
            UpdateContadorhongo(); // Actualiza el texto del HUD
            Destroy(other.gameObject); // Destruye el objeto recogido
        }
    }

    void UpdateContadorhongo()
    {
        Contadorhongo.text = "Items: " + itemCount; // Actualiza el texto del contador
    }
}