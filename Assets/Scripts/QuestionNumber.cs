using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionNumber : MonoBehaviour
{
    int questionNumber;
    int totalQuestions;

    [SerializeField] TextMeshProUGUI qNum;

    void Start()
    {
        questionNumber = 0;
    }

    public void TotalQuestionsNumber(int total)
    {
        totalQuestions = total;
    }

    public void QuestionNumberDisplay()
    {
        questionNumber++;
        qNum.text = "Q. " + questionNumber + "/" + totalQuestions;
    }
}
