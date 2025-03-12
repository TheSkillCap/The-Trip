using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator sceneTransitionAnimator; // Arrastra el Animator del SceneLoadManager en el Inspector
    public float transitionTime = 1.5f; // Ajusta esto seg�n la duraci�n de la animaci�n

    public void buttonStart()
    {
        if (sceneTransitionAnimator != null)
        {
            StartCoroutine(LoadGameScene());
        }
        else
        {
            Debug.LogError("�El Animator no est� asignado en el Inspector!");
            SceneManager.LoadScene("Game"); // En caso de error, carga la escena sin transici�n
        }
    }

    public void buttonExit()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado.");
    }

    private IEnumerator LoadGameScene()
    {
        // Activar la animaci�n de transici�n
        sceneTransitionAnimator.SetTrigger("StartTransition");

        // Esperar a que termine la animaci�n antes de cambiar de escena
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Game");
    }
}
