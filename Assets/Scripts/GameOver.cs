using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.GoToLevel("lvl_1");
        }    
    }
}
