using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float quesTime = 15f; //time to ans ques
    [SerializeField] float ansTime = 5f;  //time to show ans
    float timeRemaining;
    float fillAmount;

    public static bool hardMode = true;

    public bool onQuestion = true;
    public bool loadQues = false;
    bool clkTrig = false;

    public AudioSource clk;
    public Image clock;

    void Start()
    {
        timeRemaining = quesTime;
    }

    void FixedUpdate()
    {
        if (hardMode) 
        {
            TimerUpdate();
        }
        FillUpdate();
    }

    public void CancelTimer()
    {
        timeRemaining = 0;
        clk.Stop();
        if (!hardMode)
        {
            Invoke("NoTimeQuestion", 2f);
        }
    }

    void TimerUpdate()
    {
        timeRemaining -= Time.deltaTime;
        if (onQuestion)
        {
            fillAmount = timeRemaining / quesTime;
            if (fillAmount < 0.3f && !clkTrig)
            {
                clk.Play();
                clkTrig = true;
            }
        }
        else
        {
            fillAmount = timeRemaining / ansTime;
        }
        
        if (timeRemaining <= 0 && onQuestion)
        {
            onQuestion = false;
            timeRemaining = ansTime;
            clkTrig = false;
            clk.Stop();
        }
        else if(timeRemaining<=0 && !onQuestion)
        {
            onQuestion = true;
            timeRemaining = quesTime;
            loadQues = true;
        }
    }
    
    void FillUpdate()
    {
        clock.fillAmount = fillAmount;
        if (onQuestion)
        {
            if (fillAmount < 0.3f)
            {
                clock.color = new Color(1, 0, 0, 1);
            }
            else
            {
                clock.color = new Color(0, 1, 0, 1);
            }
        }
        else
        {
            clock.color = new Color(1, 1, 1, 1);
        }
    }

    void NoTimeQuestion()
    {
        onQuestion = true;
        loadQues = true;
    }
}
