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
        Application.Quit(); // Cierra la aplicación
        Debug.Log("El juego se ha cerrado."); // Solo se verá en el Editor de Unity
    }
}
