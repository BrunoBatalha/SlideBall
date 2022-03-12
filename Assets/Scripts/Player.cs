using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    public Rigidbody2D _rigidbody2D;
    private bool isClickingMove;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ManageMovement();
    }

    private void OnValidate()
    {
        if (Speed == 0)
        {
            throw new Exception("Valor de Speed: " + Speed);
        }
    }

    private void ManageMovement()
    {     
        if (IsMoving() || isClickingMove)
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                isClickingMove = false;
            }
            return;
        }      

        MoveWithVelocity();
    }

    private bool IsMoving()
    {
        return _rigidbody2D.velocity.magnitude > 0f;
    }

    private void MoveWithVelocity()
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

    private void MoveWithImpulse()
    {
        bool toRight = Input.GetAxis("Horizontal") > 0f;
        bool toLeft = Input.GetAxis("Horizontal") < 0f;
        bool toBottom = Input.GetAxis("Vertical") > 0f;
        bool toTop = Input.GetAxis("Vertical") < 0f;

        if (toRight)
        {
            _rigidbody2D.AddForce(new Vector2(Speed, 0f), ForceMode2D.Impulse);
        }
        else if (toLeft)
        {
            _rigidbody2D.AddForce(new Vector2(-Speed, 0f), ForceMode2D.Impulse);
        }
        else if (toTop)
        {
            _rigidbody2D.AddForce(new Vector2(0f, -Speed), ForceMode2D.Impulse);
        }
        else if (toBottom)
        {
            _rigidbody2D.AddForce(new Vector2(0f, Speed), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Teleport")
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                isClickingMove = true;
            }
        }
    }
}
