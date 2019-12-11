﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel, readyButton;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        Time.timeScale = 0f;

    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayerDiedRestartGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }

    public void setScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void setCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void setLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
