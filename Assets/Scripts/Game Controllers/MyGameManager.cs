using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public static MyGameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameStartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    void OnEnable()
    {
        SceneManager.sceneLoaded += LoadedScene;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadedScene;
    }

    void LoadedScene(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SampleScene")
        {
            if (gameStartedAfterPlayerDied)
            {
                GameplayController.instance.setScore(score);
                GameplayController.instance.setLifeScore(lifeScore);
                GameplayController.instance.setCoinScore(coinScore);

                PlayerScore.scoreCount = score;
                PlayerScore.lifeCount = lifeScore;
                PlayerScore.coinCount = coinScore;
            }
            else if(gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.lifeCount = 2;
                PlayerScore.coinCount = 0;

                GameplayController.instance.setScore(0);
                GameplayController.instance.setLifeScore(2);
                GameplayController.instance.setCoinScore(0);
            }
        }
        else
        {
            Debug.Log("Druge");
        }
    }

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore < 0)
        {
            gameStartedFromMainMenu = false;
            gameStartedAfterPlayerDied = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameStartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            GameplayController.instance.PlayerDiedRestartGame();

        }
    }
}
