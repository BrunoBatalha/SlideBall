using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private string NextLevelName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == Tags.Player)
        {
            GameController.instance.LoadScene(NextLevelName);
        }
    }
}
