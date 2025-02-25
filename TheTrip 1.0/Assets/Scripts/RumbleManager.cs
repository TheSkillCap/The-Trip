using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleManager : MonoBehaviour
{
    // Singleton de la clase para acceder a ella desde otro script
    public static RumbleManager instance;

    private Gamepad gamepad;

    // Almacena el Esquema de control, sea teclado o Gamepad.
    private string controlScheme;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // M�todo que crea la vibraci�n. Necesita dos flotantes y una duraci�n.
    public void RumbleActive(float lowF, float highF, float duration)
    {
        // Obtiene el Gamepad activo.
        gamepad = Gamepad.current;

        // Si el control es el Gamepad se efect�a el m�todo SetMotorSpeed que permite la vibraci�n.
        if (controlScheme == "Gamepad")
        {
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(lowF, highF);
            }
            StartCoroutine(RumbleDuration(duration, gamepad));
        }
    }
    // Corutina para darle tiempo a la duraci�n de la vibraci�n.
    private IEnumerator RumbleDuration(float duration, Gamepad pad)
    {
        yield return new WaitForSeconds(duration);
        pad.SetMotorSpeeds(0f, 0f);
    }

    // M�todo que cambia el esquema de controles al desconectar o conectar el Gamepad.
    public void SwitchControls(PlayerInput input)
    {
        Debug.Log("El dispositivo es: " + input.currentControlScheme);
        controlScheme = input.currentControlScheme;

    }
}
