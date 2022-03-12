using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [SerializeField]
    private GameObject teleport1;

    [SerializeField]
    private GameObject teleport2;

    // Start is called before the first frame update
    void Start()
    {
        teleport1.GetComponent<Teleport>().OnTriggerEnter += (trigged) => TeleportManager_OnTriggerEnter(trigged, teleport2);
        teleport1.GetComponent<Teleport>().OnTriggerExit += TeleportManager_OnTriggerExit;

        teleport2.GetComponent<Teleport>().OnTriggerEnter += (trigged) => TeleportManager_OnTriggerEnter(trigged, teleport1);
        teleport2.GetComponent<Teleport>().OnTriggerExit += TeleportManager_OnTriggerExit;
    }

    private void TeleportManager_OnTriggerEnter(GameObject gameObjectTrigged, GameObject teleportTo)
    {
        gameObjectTrigged.gameObject.transform.position = teleportTo.gameObject.transform.position;
        gameObjectTrigged.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        teleportTo.GetComponent<Teleport>().canTeleport = false;
    }


    private void TeleportManager_OnTriggerExit(Teleport teleport)
    {
        teleport.canTeleport = true;
    }

}
