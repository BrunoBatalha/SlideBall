using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private Rigidbody2D _rigidbody2D;
    private bool isClickingToMove;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameController.instance.canMovementPlayer)
        {
            ManageMovement();
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }

    private void ManageMovement()
    {
        if (IsMoving())
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                isClickingToMove = false;
            }
        }
        else
        {
            Move();
        }
    }

    private bool IsMoving()
    {
        return _rigidbody2D.velocity.magnitude > 0f || isClickingToMove;
    }

    private void Move()
    {
        bool toRight = Input.GetAxis("Horizontal") > 0f;
        bool toLeft = Input.GetAxis("Horizontal") < 0f;
        bool toBottom = Input.GetAxis("Vertical") > 0f;
        bool toTop = Input.GetAxis("Vertical") < 0f;

        if (toRight)
        {
            _rigidbody2D.velocity = new Vector2(Speed, 0f);
        }
        else if (toLeft)
        {
            _rigidbody2D.velocity = new Vector2(-Speed, 0f);
        }
        else if (toTop)
        {
            _rigidbody2D.velocity = new Vector2(0f, -Speed);
        }
        else if (toBottom)
        {
            _rigidbody2D.velocity = new Vector2(0f, Speed);
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Teleport)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                isClickingToMove = true;
            }
        }
    }   
}
