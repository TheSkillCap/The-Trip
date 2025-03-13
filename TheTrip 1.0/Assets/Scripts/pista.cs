using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
    public GameObject canvasUI; // Asigna aquí el Canvas desde el Inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasUI.SetActive(true); // Activa el Canvas al colisionar
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvasUI.SetActive(false); // Desactiva el Canvas con la tecla "Esc"
        }
    }
}