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

    void InitializeVariables()
    {
        if(PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficulty(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);

            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetMusicState(0);
            PlayerPrefs.SetInt("Game Initialized", 1);
        }
    }

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
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
            if(GamePreferences.GetEasyDifficulty() == 1)
            {
                int highScore = GamePreferences.GetEasyDifficultyHighScore();
                int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

                if(highScore < score)
                {
                    GamePreferences.SetEasyDifficultyHighScore(score);
                }

                if(coinHighScore < coinScore)
                {
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);
                }

            }
            if (GamePreferences.GetMediumDifficulty() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighScore();
                int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();

                if (highScore < score)
                {
                    GamePreferences.SetMediumDifficultyHighScore(score);
                }

                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);
                }

            }
            if (GamePreferences.GetHardDifficulty() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighScore();
                int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();

                if (highScore < score)
                {
                    GamePreferences.SetHardDifficultyHighScore(score);
                }

                if (coinHighScore < coinScore)
                {
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);
                }

            }
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
