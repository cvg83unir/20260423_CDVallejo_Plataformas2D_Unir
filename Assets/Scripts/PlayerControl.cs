using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    CharacterController2D characterController2D;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference punch;

    private Vector2 rawMove = Vector2.zero;

    private void Awake()
    {
        this.characterController2D = GetComponent<CharacterController2D>();

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

    //private void Update()
    //{
        
    //}



    private void OnMove(InputAction.CallbackContext context)
    {
        this.rawMove = context.action.ReadValue<Vector2>();
        characterController2D.SetRawMove(this.rawMove);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        characterController2D.Jump();
    }

    private void OnPunch(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }


}
