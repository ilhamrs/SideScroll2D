using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject gameFinishPanel;

    public GameObject player;
    public SoundManager soundManager;

    private bool onPause;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        onPause = false;
        isGameOver = false;

        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameFinishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            Pause();
        }

        if(player.GetComponent<Health>().currentHealth <= 0)
        {
            isGameOver = true;
            Invoke("GameOver", 1);
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        soundManager.loseSound();
        Time.timeScale = 0;
    }

    public void GameFinish()
    {
        gameFinishPanel.SetActive(true);
        soundManager.winSound();
        Time.timeScale = 0;
    }

    public void NextStage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        if (onPause)
        {
            onPause = false;
            Time.timeScale = 1;
        }
        else
        {
            onPause = true;
            Time.timeScale = 0;
        }
        pausePanel.SetActive(onPause);
    }
}
