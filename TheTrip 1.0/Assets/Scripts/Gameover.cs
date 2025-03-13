using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    public Button exitButton; // Referencia al bot�n

    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(GoToMenu);
        }
        else
        {
            Debug.LogError("El bot�n Exit no est� asignado en el Inspector.");
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("menu"); // Cambia a la escena "menu"
    }
}
