using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator sceneTransitionAnimator; // Arrastra el Animator del SceneLoadManager en el Inspector
    public float transitionTime = 1.5f; // Ajusta esto según la duración de la animación

    public void buttonStart()
    {
        if (sceneTransitionAnimator != null)
        {
            StartCoroutine(LoadGameScene());
        }
        else
        {
            Debug.LogError("¡El Animator no está asignado en el Inspector!");
            SceneManager.LoadScene("Game"); // En caso de error, carga la escena sin transición
        }
    }

    public void buttonExit()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado.");
    }

    private IEnumerator LoadGameScene()
    {
        // Activar la animación de transición
        sceneTransitionAnimator.SetTrigger("StartTransition");

        // Esperar a que termine la animación antes de cambiar de escena
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Game");
    }
}
