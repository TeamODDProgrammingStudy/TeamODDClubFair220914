using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Managers;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class QuizCreator : MonoBehaviour
{
    public int DefaultLifeCount = 2;
    public List<Quiz> CurrentQuizList;
    public Quiz CurrentQuiz;
    [SerializeField] private TextMeshProUGUI Question;
    [SerializeField] private QuizButton[] _quizButtons;
    [SerializeField] private int CurrentQuestionLife = 2;
    [SerializeField] private AnswerPanel _answerPanel;
    [SerializeField] private EndPanel _endPanel;
    [SerializeField] private UITimer _uiTimer;
    public UnityEvent OnWrongAnswerClicked;
    public UnityEvent OnCorrectAnswerClicked;
    public void SetQuizList(List<Quiz> quizList)
    {
        CurrentQuizList = quizList;
        ResetCondition();
    }
    public void UpdateQuiz()
    {
        int pos = Random.Range(0,CurrentQuizList.Count);
        CurrentQuiz = CurrentQuizList[pos];
        Question.text = CurrentQuiz.Question;
        int count = 0;
        foreach (var selection in CurrentQuiz.Selection) {
            _quizButtons[count].Init(selection);
            count++;
        }
        for (int i = count; i < _quizButtons.Length; i++)
        {
            _quizButtons[i].gameObject.SetActive(false);
        }
        CurrentQuizList.Remove(CurrentQuiz);
    }

    private void EndGame()
    {
        _endPanel.Init();
        CurrentQuiz = null;
        CurrentQuizList = null;
    }

    public void OnAnswerClicked(int number)
    {
        if (number !=  CurrentQuiz.Answer) {
            Wrong();
        }
        else {
            Correct();
        }
    }

    private void Correct()
    {
        OnCorrectAnswerClicked.Invoke();
        GameManager.Current.CurrentPlayerPoint++;
        _uiTimer.StopTimer();
        //정답을 맞췄으므로 정답창 띄우기
        _answerPanel.Success(
            CurrentQuiz.Answer,
            CurrentQuiz.Selection[CurrentQuiz.Answer-1],
            CurrentQuizList.Count);
    }
    //틀렸을 경우 틀림 이벤트 출력
    public void Wrong()
    {
        OnWrongAnswerClicked.Invoke();
        CurrentQuestionLife--;
        //라이프가 0보다 작을 경우 오답창 띄우기
        if (CurrentQuestionLife <=0) {
            _uiTimer.StopTimer();
            _answerPanel.Failed(
                CurrentQuiz.Answer,
                CurrentQuiz.Selection[CurrentQuiz.Answer-1],
                CurrentQuizList.Count);
            return;
        }
        _uiTimer.StartTimer(10f);
    }

    public void ResetCondition()
    {
        CurrentQuestionLife = DefaultLifeCount;
        if (CurrentQuizList.Count <=0) {
            EndGame();
            return;
        }
        _uiTimer.StartTimer(10f);
        UpdateQuiz();
    }

    public void Exit()
    {
        CurrentQuizList?.Clear();
        _uiTimer.StopTimer();
    }
    private void OnValidate()
    {
        _quizButtons = GetComponentsInChildren<QuizButton>();
    }
}