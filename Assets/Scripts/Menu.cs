using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    [SerializeField]
    private AudioSource audioHover;

    [SerializeField]
    private AudioSource audioClick;


    private void Awake()
    {
        instance = this;
    }   

    public void PlayHover()
    {
        audioHover.Play();
    }

    public void PlayClick()
    {
        audioClick.Play();
    }
}
