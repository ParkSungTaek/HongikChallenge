using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Question
{
    //public string From;
    public string Q1 = "";
    public string Q2 = "";
    public string Q3 = "";
    public int A1 = 0;
    public int A2 = 0;
    public int A3 = 0;
}
public class QuestionWrapper 
{
    List<Question> questions = new List<Question>();

    public void Add(Question question)
    {
        questions.Add(question);
    }
    public Question this[int idx]
    {
        get => questions[idx];
        set => questions[idx] = value;
    }
}
