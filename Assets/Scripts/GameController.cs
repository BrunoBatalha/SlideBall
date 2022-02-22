using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GoToLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

}
