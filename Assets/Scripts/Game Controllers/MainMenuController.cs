﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("HighscoreScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MusicButton()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
