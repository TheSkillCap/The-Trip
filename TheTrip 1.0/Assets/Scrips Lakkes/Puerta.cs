using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Asegúrate de importar UI para los botones

public class Puerta : MonoBehaviour
{
    public GameObject CanvasPuerta; // Referencia al Canvas del puzzle
    public Button[] botones; // Array de botones
    public int[] ordenCorrecto = { 0, 1, 2 }; // Orden correcto (ajusta según tus botones)

    private int[] ordenJugador; // Registro de la secuencia del jugador
    private int indexActual = 0; // Índice del jugador
    private bool puzzleCompletado = false; // Variable para evitar que el puzzle se vuelva a mostrar

    void Start()
    {
        ordenJugador = new int[ordenCorrecto.Length];

        // Asignar eventos de clic a los botones
        for (int i = 0; i < botones.Length; i++)
        {
            int indice = i; // Necesario para evitar problemas de referencias en el bucle
            botones[i].onClick.AddListener(() => BotonPresionado(indice));
        }

        // Asegurarse de que el CanvasPuerta esté desactivado al inicio
        CanvasPuerta.SetActive(false);
    }

    void Update()
    {
        // Si presiona "E", cierra el Canvas de la puerta y reanuda el juego
        if (Input.GetKeyDown(KeyCode.E))
        {
            CerrarCanvasPuerta();
        }
    }

    void BotonPresionado(int botonID)
    {
        if (indexActual < ordenCorrecto.Length)
        {
            ordenJugador[indexActual] = botonID;
            indexActual++;

            if (indexActual == ordenCorrecto.Length)
            {
                VerificarOrden();
            }
        }
    }

    void VerificarOrden()
    {
        bool esCorrecto = true;
        for (int i = 0; i < ordenCorrecto.Length; i++)
        {
            if (ordenJugador[i] != ordenCorrecto[i])
            {
                esCorrecto = false;
                break;
            }
        }

        if (esCorrecto)
        {
            Debug.Log("¡Puzzle completado!");
            puzzleCompletado = true; // Marca el puzzle como completado
            SceneManager.LoadScene("Ganaste"); // Cargar la escena "Ganaste"
        }
        else
        {
            Debug.Log("Orden incorrecto, intenta de nuevo.");
            ReiniciarPuzzle();
        }
    }

    void ReiniciarPuzzle()
    {
        indexActual = 0; // Reinicia la selección del jugador
    }

    public void CerrarCanvasPuerta()
    {
        CanvasPuerta.SetActive(false);
        Time.timeScale = 1f; // Reactiva el juego
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "Player"
        {
            Debug.Log("Colisión detectada con el puzzle.");

            if (!puzzleCompletado)
            {
                // Si el puzzle no se ha completado, muestra el CanvasPuerta
                CanvasPuerta.SetActive(true);
                Time.timeScale = 0f; // Pausa el juego mientras el canvas está activo
            }
        }
    }
}
