using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Asigna en el Inspector el menú de pausa
    public GameObject hud; // Asigna en el Inspector el HUD del juego
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa el juego
        pauseMenu.SetActive(true); // Muestra el menú de pausa
        hud.SetActive(false); // Oculta el HUD
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el juego
        pauseMenu.SetActive(false); // Oculta el menú de pausa
        hud.SetActive(true); // Muestra el HUD nuevamente
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo vuelva a la normalidad
        SceneManager.LoadScene("Menu"); // Cambia a la escena del menú principal
    }
}
