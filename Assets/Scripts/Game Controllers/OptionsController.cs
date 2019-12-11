using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;
    
    void Start()
    {
        SetDifficulty();
    }

    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                mediumSign.active = false;
                hardSign.active = false;
                break;

            case "medium":
                easySign.active = false;
                hardSign.active = false;
                break;

            case "hard":
                easySign.active = false;
                mediumSign.active = false;
                break;
        }
    }

    void SetDifficulty()
    {
        if(GamePreferences.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreferences.SetEasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easySign.active = true;
        mediumSign.active = false;
        hardSign.active = false;
    }

    public void MediumDifficulty()
    {
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetHardDifficulty(0);

        easySign.active = false;
        mediumSign.active = true;
        hardSign.active = false;
    }

    public void HardDifficulty()
    {
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(1);

        easySign.active = false;
        mediumSign.active = false;
        hardSign.active = true;
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
