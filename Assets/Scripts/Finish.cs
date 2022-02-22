using UnityEngine;

public class Finish : MonoBehaviour
{
    public string NextLevelName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.GoToLevel(NextLevelName);
        }
    }
}
