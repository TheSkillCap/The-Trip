using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    public Button exitButton; // Referencia al botón

    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(GoToMenu);
        }
        else
        {
            Debug.LogError("El botón Exit no está asignado en el Inspector.");
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("menu"); // Cambia a la escena "menu"
    }
}
