using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class QuizCreator : MonoBehaviour
{
    public int ReselectCount = 2;
    public List<Quiz> CurrentQuizList;
    public Quiz CurrentQuiz;
    private QuizButton[] _quizButtons;
    public void SetQuizList(List<Quiz> quizList)
    {
        CurrentQuizList = quizList;
        UpdateQuiz();
    }
    private void UpdateQuiz()
    {
        int pos = Random.Range(0,CurrentQuizList.Count);
        CurrentQuiz = CurrentQuizList[pos];
        
        CurrentQuizList.Remove(CurrentQuiz);
    }
    private void OnValidate()
    {
        _quizButtons = GetComponentsInChildren<QuizButton>();
    }
}