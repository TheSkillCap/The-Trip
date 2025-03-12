using UnityEngine;
using UnityEngine.Events;

public class CookiesPuzzle: MonoBehaviour
{
    public GameObject[] figuras; // Array de las 3 figuras
    public int[] ordenCorrecto = { 0, 1, 2 }; // Orden correcto de las figuras (�ndices del array)
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
        // Verificar si las figuras est�n en el orden correcto
        if (VerificarOrden())
        {
            Debug.Log("�Minijuego completado!");
            onCookiesPuzzleComplete.Invoke(); // Disparar el evento de completado
            enabled = false; // Desactivar el script
        }
    }

    // M�todo para verificar el orden de las figuras
    private bool VerificarOrden()
    {
        for (int i = 0; i < figuras.Length; i++)
        {
            // Comparar la posici�n de cada figura con la posici�n correcta
            if (figuras[i].transform.position != posicionesIniciales[ordenCorrecto[i]])
            {
                return false; // Si alguna figura no est� en su lugar, retornar falso
            }
        }
        return true; // Si todas las figuras est�n en su lugar, retornar verdadero
    }

    // M�todo para reiniciar el minijuego
    public void ReiniciarMinijuego()
    {
        for (int i = 0; i < figuras.Length; i++)
        {
            figuras[i].transform.position = posicionesIniciales[i]; // Restaurar posiciones iniciales
        }
    }
}
