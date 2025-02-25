using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Se crea un Singleton para acceder a los elementos de esta clase en otras.
    public static PlayerController instance;
   
    // Variable para almacenar el componente del Input.
    [HideInInspector] public PlayerInput playerInput;
    private Rigidbody rb;

    // Variables de velocidad.
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Jump Parameters")]
    [SerializeField] private int jumpSpeed;

    // las interacciones para obtener las teclas presionadas.
    private Vector2 inputM;
    [HideInInspector] public float inputI;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        
    }

    private void Update()
    {
        // Se relacionan las variables de los inputs con las enradas.
        inputM = playerInput.actions["Move"].ReadValue<Vector2>();
        inputI = playerInput.actions["Interact"].ReadValue<float>(); 
       
    }

    private void FixedUpdate()
    {
        //Llamar el método.
        Move();
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed) 
        {
            // Se efectúa cuando la acción se realiza y cuando el jugador no tiene velocidad en Y.
            if (Mathf.Abs(rb.velocity.y) < 0.01)
            {
                rb.AddForce(Vector3.up * jumpSpeed);
            }
        }

    }

    public void Move()
    {
        //Se realiza el movimiento del personaje, manipulando su velocidad.
        rb.velocity = new Vector3(inputM.x, 0, inputM.y) * moveSpeed;
    }

    public void Sprint(InputAction.CallbackContext callbackContext)
    {
        // Cambia la velocidad cuando el llamado se ejecuta.
        if (callbackContext.performed)
        {
            moveSpeed *= sprintMultiplier;
            
        // La velocidad se reinicia ciuando se cancela la acción.
        } else if (callbackContext.canceled)
        {
            moveSpeed /= sprintMultiplier;
                
        }
        
    }
 }
