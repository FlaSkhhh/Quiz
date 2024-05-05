using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainQuiz : MonoBehaviour
{
    public List<Question> questions;
    Question currentQues;

    public TextMeshProUGUI questionText;
    public GameObject[] answers;
    public Sprite bluSprite;
    public Sprite ornSprite;

    public AudioSource correctAud;
    public AudioSource wrongAud;

    public bool hasAnsweredEarly = true;
    public bool gameComplete  = false;

    public static int correctAnswers = 0;
    public static int maxQuestions=10;

    int correctOption;
    int qCount = 0;

    public QuestionNumber quesNum;
    Timer timer;

    void Awake()
    {
        if (maxQuestions == 0)
        {
            maxQuestions = questions.Count;
        }
        quesNum.TotalQuestionsNumber(maxQuestions);
    }

    void Start()
    {
        NextQuestion();
        timer = FindObjectOfType<Timer>();
        correctAnswers = 0;
        wrongAud.volume = Settings.volumeAmount;
        correctAud.volume = Settings.volumeAmount;
    }

    void Update()
    {
        if (timer.loadQues)
        {
            hasAnsweredEarly = false;
            timer.loadQues = false;
            NextQuestion();
        }
        else if (!hasAnsweredEarly && !timer.onQuestion)
        {
            DisplayAnswer(-1);
            ButtonInteraction(false);
        }
    }

    public void ButtonPress(int num)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(num);
        ButtonInteraction(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int num)
    {
        if (num == correctOption)
        {
            correctAud.Play();
            questionText.text = "Bravo";
            Image img = answers[num].GetComponent<Image>();
            img.sprite = ornSprite;
            correctAnswers++;
        }
        else
        {
            wrongAud.time=0.6f;
            wrongAud.Play();
            questionText.text = "Womp Womp";
            Image img = answers[correctOption].GetComponent<Image>();
            img.sprite = ornSprite;
        }
    }

    void NextQuestion()
    {
        wrongAud.Stop();
        correctAud.Stop();
        if (qCount==maxQuestions)
        {
            gameComplete = true;
            return;
        }

        if (questions.Count > 0)
        {
            qCount++;
            quesNum.QuestionNumberDisplay();
            ButtonInteraction(true);
            GetRandomQuestion();
            QuestionStart();
        }
    }

    void ButtonInteraction(bool currentState)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            Button butt = answers[i].GetComponent<Button>();
            butt.interactable = currentState;
        }
        if (currentState)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                Image butt = answers[i].GetComponent<Image>();
                butt.sprite = bluSprite;
            }
        }
    }

    void GetRandomQuestion()
    {
        int rng = Random.Range(0, questions.Count);
        currentQues = questions[rng];
        if (questions.Contains(currentQues))
        {
           questions.RemoveAt(rng);
        }
    }

    void QuestionStart()
    {
        questionText.text = currentQues.GetQuestion();
        correctOption = currentQues.GetCorrectOption();

        for (int i = 0; i < answers.Length; i++)
        {
            Text optionText = answers[i].GetComponentInChildren<Text>();
            optionText.text = currentQues.GetOptions(i);
        }
    }
}
