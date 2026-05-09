using UnityEngine;

public class AIControl : MonoBehaviour
{
    CharacterController2D characterController2D;

    [SerializeField] Transform target;

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

        }

        characterController2D.SetRawMove(rawMove);
    }
}
