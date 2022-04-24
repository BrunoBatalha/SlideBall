using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField]
    private string NextLevelName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            GameController.instance.NextLevel(NextLevelName);
        }
    }
}
