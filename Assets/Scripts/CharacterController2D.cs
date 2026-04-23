using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 rawMove = Vector2.zero;
    private const float moveThreshold = 0.1f;

    [SerializeField] float movementSpeed = 3f;
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference punch;

    private void Awake()
    {
        //Cacheamos el rigidbody, el animator y el spriteRenderer
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        //Así cogemos las acciones del personaje sólo cuando hay alguna interacción por parte del jugador
        move.action.started += OnMove;
        move.action.canceled += OnMove;
        move.action.performed += OnMove;
        jump.action.started += OnJump;

        punch.action.started += OnPunch;
    }

    private void OnEnable()
    {
        move.action.Enable();
        jump.action.Enable();
        punch.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
        jump.action.Disable();
        punch.action.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de nuestro personaje
        this.rb2D.linearVelocity = this.rawMove * this.movementSpeed * Time.deltaTime;

        //Determinamos si el personaje tiene que estar corriendo o no:
        bool isMoving = Math.Abs(this.rawMove.x) > moveThreshold;

        this.animator.SetBool("IsRunning", isMoving);

        //Además, si se está moviendo pero hacia la izquierda, hay que girar al personaje en el eje de las X:
        if (isMoving)
        {
            this.spriteRenderer.flipX = rawMove.x < 0f;
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        this.rawMove = context.action.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void OnPunch(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
