using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using static UnityEditor.PlayerSettings.SplashScreen;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const float moveThreshold = 0.1f;

    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpVelocity = 5f;
    
    [Header("Ground Check")]
    [SerializeField] float groundCheckDistance = 0.2f;
    [SerializeField] LayerMask groundLayerMask = Physics2D.DefaultRaycastLayers;

    private Vector2 rawMove = Vector2.zero;


    private void Awake()
    {
        //Cacheamos el rigidbody, el animator y el spriteRenderer
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento de nuestro personaje
        this.rb2D.linearVelocityX = this.rawMove.x * this.movementSpeed * Time.deltaTime;

        //Determinamos si el personaje tiene que estar corriendo o no:
        bool isMoving = Math.Abs(this.rawMove.x) > moveThreshold;

        this.animator.SetBool("IsRunning", isMoving);

        //Además, si se está moviendo pero hacia la izquierda, hay que girar al personaje en el eje de las X:
        if (isMoving)
        {
            this.spriteRenderer.flipX = rawMove.x < 0f;
        }


        this.animator.SetBool("IsGrounded", IsGrounded());

    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);


        return hit && (hit.collider != null);
    }

    public void SetRawMove(Vector2 rawmove)
    {
        this.rawMove = rawmove;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    internal void Jump()
    {

        if (IsGrounded())
        {
            
            this.rb2D.linearVelocityY = this.jumpVelocity;
        }

    }
}
