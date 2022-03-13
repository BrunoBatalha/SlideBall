using UnityEngine;

public class Platform : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }     

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == Tags.Player)
        {
            audioSource.Play();
        }
    }
}
