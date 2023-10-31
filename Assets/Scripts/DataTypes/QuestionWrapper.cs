using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Question
{
    //public string From;
    public string Q1;
    public string Q2;
    public string Q3;
    public int A1;
    public int A2;
    public int A3;
}
public class QuestionWrapper 
{
    List<Question> questions;

    /// <summary>
    /// 리스트 초기화
    /// questions = new List<Question>(size);
    /// </summary>
    /// <param name="size"></param>
    public void Init(int size)
    {
        questions = new List<Question>(size);
    }

    public Question this[int idx]
    {
        get => questions[idx];
        set => questions[idx] = value;
    }
}
