using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private AudioSource gameOverAudio;
    [SerializeField]
    private AudioSource nextLevelAudio;
    public bool canMovementPlayer = true;

    void Start()
    {
        instance = this;
        gameOverAudio = GetComponent<AudioSource>();
        nextLevelAudio = GetComponent<AudioSource>();
    }  

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene("Menu");
        }

        if (instance == null)
        {
            instance = this;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void LoadScene(string sceneName)
    {
        canMovementPlayer = true;
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        canMovementPlayer = false;
        gameOverAudio.Play();
        StartCoroutine(WaiterLoadScene("lvl_0"));
    }

    public void NextLevel(string sceneName)
    {
        canMovementPlayer = false;
        nextLevelAudio.Play();
        StartCoroutine(WaiterLoadScene(sceneName));
    }

    IEnumerator WaiterLoadScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(2);
        LoadScene(sceneName);
    }
}
