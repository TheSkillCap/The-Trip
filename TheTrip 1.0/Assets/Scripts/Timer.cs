using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referencia al texto del Timer
    private float timeRemaining = 120f; // 2 minutos (120 segundos)
    private bool isRunning = true; // Controla si el timer sigue corriendo

    void Start()
    {
        UpdateTimerText(); // Asegura que el tiempo inicial se muestre correctamente
    }

    void Update()
    {
        if (isRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Reduce el tiempo
            UpdateTimerText();
        }
        else if (timeRemaining <= 0 && isRunning)
        {
            timeRemaining = 0; // Evita valores negativos
            isRunning = false;
            LoadGameOverScene(); // Cargar la escena "Game Over"
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.LogError("⚠️ El TextMeshProUGUI no está asignado. Arrástralo en el Inspector.");
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over"); // Asegúrate de que la escena esté en el Build Settings
    }
}
