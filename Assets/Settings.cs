using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject homePage;
    [SerializeField] GameObject settingsPage;
    [SerializeField] GameObject infoTextBox;
    [SerializeField] AudioSource aud;

    public static float volumeAmount;
    bool infoTextBool = false;
   
    public void Back()
    {
        settingsPage.SetActive(false);
        homePage.SetActive(true);
        infoTextBox.SetActive(false);
        infoTextBool = false;
    }

    public void HardMode(bool value)
    {
        Timer.hardMode = value;
    }

    public void Info()
    {
        infoTextBool=!infoTextBool;
        infoTextBox.SetActive(infoTextBool);
    }

    public void DropDown(int index)
    {
        switch (index)
        {
            case 0: MainQuiz.maxQuestions = 5;
                break;
            case 1: MainQuiz.maxQuestions = 10;
                break;
            case 2: MainQuiz.maxQuestions = 0;
                break;
        }
    }

    public void Volume(float vol)
    {
        volumeAmount = vol;
        aud.volume = volumeAmount;
    }
}
