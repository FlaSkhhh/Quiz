using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Question : ScriptableObject
{
    [SerializeField]
    [TextArea(2, 4)]
    string question = "???";

    [SerializeField]
    [TextArea(2, 1)]
    string[] options;

    [SerializeField]
    int correctAnswer;

    public string GetQuestion()
    {
        return question;
    }

    public string GetOptions(int opt)
    {
        return options[opt];
    }

    public int GetCorrectOption()
    {
        return correctAnswer;
    }
}