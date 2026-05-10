using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AIControl : MonoBehaviour
{
    CharacterController2D characterController2D;

    [SerializeField] Transform target;
    [SerializeField] float attackDistance = 2f;

    internal void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Awake()
    {
        this.characterController2D = GetComponent<CharacterController2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rawMove = Vector2.zero;
        if (this.target)
        {
            if(transform.position.x > target.position.x)
            {
                rawMove = Vector2.left;
            }
            else
            {
                rawMove = Vector2.right;
            }

            //Cuando el enemigo esté lo suficientemente cerca de su objetivo, que se pare y dé puñetazos
            if(Mathf.Abs(target.transform.position.x - transform.position.x)<attackDistance)
            {
                rawMove = Vector2.zero;
                this.characterController2D.Punch();
            }

        }

        characterController2D.SetRawMove(rawMove);
    }
}
