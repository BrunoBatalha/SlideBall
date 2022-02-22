using UnityEngine;

public class Player : MonoBehaviour
{
    public float Velocity;
    private Rigidbody2D _rigidbody2D;
    private bool _isMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Teste");
            Application.Quit();
        }

        if (_isMovement)
        {
            return;
        }

        bool toRight = Input.GetAxis("Horizontal") > 0f;
        bool toLeft = Input.GetAxis("Horizontal") < 0f;
        bool toBottom = Input.GetAxis("Vertical") > 0f;
        bool toTop = Input.GetAxis("Vertical") < 0f;

        if (toRight)
        {
            _rigidbody2D.velocity = new Vector2(Velocity, 0f);
        }
        else if (toLeft)
        {
            _rigidbody2D.velocity = new Vector2(-Velocity, 0f);
        }
        else if (toTop)
        {
            _rigidbody2D.velocity = new Vector2(0f, -Velocity);
        }
        else if (toBottom)
        {
            _rigidbody2D.velocity = new Vector2(0f, Velocity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            _isMovement = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            _isMovement = true;
        }
    }
}
