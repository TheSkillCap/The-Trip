using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject canvasPuzzle; // Referencia al Canvas del puzzle
    public GameObject canvasSuccess; // Canvas de éxito (mensaje de "Puzzle Completado")
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

        // Asegurarse de que los canvas estén desactivados al inicio
        canvasPuzzle.SetActive(false);
        canvasSuccess.SetActive(false);
    }

    void Update()
    {
        // Si presiona "Q", cierra el Canvas del puzzle y reanuda el juego
        if (Input.GetKeyDown(KeyCode.E))
        {
            CerrarCanvasPuzzle();
        }

        // Si presiona "T", cierra el Canvas de éxito
        if (Input.GetKeyDown(KeyCode.E))
        {
            CerrarCanvasSuccess();
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
            canvasSuccess.SetActive(true); // Muestra la pantalla de éxito
            canvasPuzzle.SetActive(false); // Oculta el Canvas del puzzle
            Time.timeScale = 0f; // Mantiene pausado hasta que el jugador cierre el éxito
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

    public void CerrarCanvasPuzzle()
    {
        canvasPuzzle.SetActive(false);
        Time.timeScale = 1f; // Reactiva el juego
    }

    public void CerrarCanvasSuccess()
    {
        canvasSuccess.SetActive(false);
        Time.timeScale = 1f; // Reactiva el juego
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "player"
        {
            Debug.Log("Colisión detectada con el puzzle.");

            if (puzzleCompletado)
            {
                // Si el puzzle ya se completó, solo muestra el canvas de éxito
                canvasSuccess.SetActive(true);
            }
            else
            {
                // Si el puzzle no se ha completado, muestra el canvas del puzzle
                canvasPuzzle.SetActive(true);
            }

            Time.timeScale = 0f; // Pausa el juego mientras el canvas está activo
        }
    }
}
