using System;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public event Action<GameObject> OnTriggerEnter;
    public event Action<Teleport> OnTriggerExit;

    [HideInInspector]
    public bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            if (canTeleport)
            {
                OnTriggerEnter(collision.gameObject);           
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.Player)
        {
            OnTriggerExit(this);
        }
    }
   
}
