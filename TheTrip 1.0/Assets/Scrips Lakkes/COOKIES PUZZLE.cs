using UnityEngine;
using UnityEngine.Events;

public class CookiesPuzzle: MonoBehaviour
{
    public GameObject[] figuras; // Array de las 3 figuras
    public int[] ordenCorrecto = { 0, 1, 2 }; // Orden correcto de las figuras (índices del array)
    public UnityEvent onCookiesPuzzleComplete; // Evento que se dispara cuando el minijuego se completa

    private Vector3[] posicionesIniciales; // Guarda las posiciones iniciales de las figuras

    void Start()
    {
        // Guardar las posiciones iniciales de las figuras
        posicionesIniciales = new Vector3[figuras.Length];
        for (int i = 0; i < figuras.Length; i++)
        {
            posicionesIniciales[i] = figuras[i].transform.position;
        }
    }

    void Update()
    {
        // Verificar si las figuras están en el orden correcto
        if (VerificarOrden())
        {
            Debug.Log("¡Minijuego completado!");
            onCookiesPuzzleComplete.Invoke(); // Disparar el evento de completado
            enabled = false; // Desactivar el script
        }
    }

    // Método para verificar el orden de las figuras
    private bool VerificarOrden()
    {
        for (int i = 0; i < figuras.Length; i++)
        {
            // Comparar la posición de cada figura con la posición correcta
            if (figuras[i].transform.position != posicionesIniciales[ordenCorrecto[i]])
            {
                return false; // Si alguna figura no está en su lugar, retornar falso
            }
        }
        return true; // Si todas las figuras están en su lugar, retornar verdadero
    }

    // Método para reiniciar el minijuego
    public void ReiniciarMinijuego()
    {
        for (int i = 0; i < figuras.Length; i++)
        {
            figuras[i].transform.position = posicionesIniciales[i]; // Restaurar posiciones iniciales
        }
    }
}
