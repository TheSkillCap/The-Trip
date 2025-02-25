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

    // Método que crea la vibración. Necesita dos flotantes y una duración.
    public void RumbleActive(float lowF, float highF, float duration)
    {
        // Obtiene el Gamepad activo.
        gamepad = Gamepad.current;

        // Si el control es el Gamepad se efectúa el método SetMotorSpeed que permite la vibración.
        if (controlScheme == "Gamepad")
        {
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(lowF, highF);
            }
            StartCoroutine(RumbleDuration(duration, gamepad));
        }
    }
    // Corutina para darle tiempo a la duración de la vibración.
    private IEnumerator RumbleDuration(float duration, Gamepad pad)
    {
        yield return new WaitForSeconds(duration);
        pad.SetMotorSpeeds(0f, 0f);
    }

    // Método que cambia el esquema de controles al desconectar o conectar el Gamepad.
    public void SwitchControls(PlayerInput input)
    {
        Debug.Log("El dispositivo es: " + input.currentControlScheme);
        controlScheme = input.currentControlScheme;

    }
}
