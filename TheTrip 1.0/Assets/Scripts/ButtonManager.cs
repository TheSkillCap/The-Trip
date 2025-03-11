using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void buttonStart()
    {
        SceneManager.LoadScene("Game"); // Faltaba el ';'
    }

    public void buttonExit()
    {
        Application.Quit(); // Cierra la aplicaci�n
        Debug.Log("El juego se ha cerrado."); // Solo se ver� en el Editor de Unity
    }
}
