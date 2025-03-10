using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [HideInInspector] public PlayerInput playerInput;
    private Rigidbody rb;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float sprintMultiplier = 2.0f;
    private bool isSprinting = false;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpSpeed = 5f;

    [Header("Drug Effect Controller")]
    public DrugEffectController drugEffectController; // Asigna en el Inspector

    private Vector2 inputM;
    [HideInInspector] public float inputI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Previene múltiples instancias
            return;
        }

        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        inputM = playerInput.actions["Move"].ReadValue<Vector2>();
        inputI = playerInput.actions["Interact"].ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        float speed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;
        rb.velocity = new Vector3(inputM.x * speed, rb.velocity.y, inputM.y * speed);
    }

    public void Sprint(InputAction.CallbackContext callbackContext)
    {
        isSprinting = callbackContext.performed;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("CuboAumentador"))
        {
            if (drugEffectController != null)
            {
                drugEffectController.IncreaseEffects(); // Aumenta el efecto
            }

            Destroy(other.gameObject); // Destruye el cubo al tocarlo
        }
    }
}
