using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTest : MonoBehaviour
{
    public Text text;
    int score;

    [SerializeField] GameObject highScore;
    [SerializeField] GameObject midScore;
    [SerializeField] GameObject lowScore;

    void Awake()
    {
        score = MainQuiz.correctAnswers;
    }

    void Start()
    {
        float scorePercent = score / (float)MainQuiz.maxQuestions;
        if(scorePercent <= 0.35)
        {
            lowScore.SetActive(true);
            text.color = new Color(0.8f, 0.18f, 0.18f, 1f);
        }
        else if(scorePercent > 0.35 && scorePercent <= 0.7)
        {
            midScore.SetActive(true);
            text.color = new Color(0.9f, 0.8f, 0.24f, 1f);
        }
        else if (scorePercent > 0.7)
        {
            highScore.SetActive(true);
            text.color = new Color(0.26f, 0.98f, 0.26f, 1f);
        }
        text.text = score.ToString() + "/" + MainQuiz.maxQuestions;
    }
}
