using TMPro;
using UnityEngine;

public class SquareRed : MonoBehaviour
{
    [SerializeField]
    private Color colorToAction;

    [SerializeField]
    private float timeChangeColor;

    [SerializeField]
    private float timeStart;

    [SerializeField]
    private TMP_Text stopwatchText;

    private Color colorOriginal;
    private SpriteRenderer spriteRenderer;

    private float timePassed;
    private bool isCollingPlayer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
        timePassed = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = timePassed + Time.deltaTime;

        if (timePassed > timeChangeColor && spriteRenderer.color == Color.yellow)
        {
            spriteRenderer.color = colorToAction;
            timePassed = 0;
        }
        else if (timePassed > timeChangeColor / 2 && spriteRenderer.color == colorOriginal)
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (timePassed > timeChangeColor && spriteRenderer.color == colorToAction)
        {
            spriteRenderer.color = colorOriginal;
            timePassed = 0;
        }

        stopwatchText.text = timePassed.ToString("f0");

        if (isCollingPlayer && spriteRenderer.color == colorToAction)
        {
            GameController.instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollingPlayer = collision.gameObject.tag == Tags.Player;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollingPlayer = !(collision.gameObject.tag == Tags.Player);
    }
}
