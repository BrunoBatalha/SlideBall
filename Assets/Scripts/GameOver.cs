using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == Tags.Player)
        {
            GameController.instance.LoadScene("lvl_0");
        }    
    }
}
