using System.Collections.Generic;
using Data;
using Managers;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SubjectiveQuizCreator : MonoBehaviour
{
    public int DefaultLifeCount = 1;
    public List<SubjectiveQuiz> CurrentQuizList;
    public SubjectiveQuiz CurrentQuiz;
    [SerializeField] private TextMeshProUGUI Question;
    [SerializeField] private TMP_InputField _answer;
    [SerializeField] private int CurrentQuestionLife = 2;
    [SerializeField] private AnswerPanel _answerPanel;
    [SerializeField] private EndPanel _endPanel;
    public UnityEvent OnWrongAnswerClicked;
    public UnityEvent OnCorrectAnswerClicked;
    public void SetQuizList(List<SubjectiveQuiz> quizList)
    {
        CurrentQuizList = quizList;
        ResetCondition();
    }
    public void UpdateQuiz()
    {
        int pos = Random.Range(0,CurrentQuizList.Count);
        CurrentQuiz = CurrentQuizList[pos];
        Question.text = CurrentQuiz.Question;
        CurrentQuizList.Remove(CurrentQuiz);
    }

    private void EndGame()
    {
        _endPanel.Init();
        CurrentQuiz = null;
        CurrentQuizList = null;
    }
    public void Correct()
    {
        OnCorrectAnswerClicked.Invoke();
        GameManager.Current.CurrentPlayerPoint++;
        //정답을 맞췄으므로 정답창 띄우기
        /*
        _answerPanel.Init(CurrentQuiz.Answer,_answer.text);
        */
    }
    //틀렸을 경우 틀림 이벤트 출력
    public void Wrong()
    {
        OnWrongAnswerClicked.Invoke();
        CurrentQuestionLife--;
        //라이프가 0보다 작을 경우 오답창 띄우기
        /*
        if (CurrentQuestionLife <=0) {
            _answerPanel.Init(CurrentQuiz.Answer,_answer.text);
            return;
        }
        */
    }

    public void CheckAnswer()
    {
        _answerPanel.Init(CurrentQuiz.Answer,_answer.text);
    }

    public void ResetCondition()
    {
        CurrentQuestionLife = DefaultLifeCount;
        _answer.text = string.Empty;
        if (CurrentQuizList.Count <=0) {
            EndGame();
            return;
        }
        UpdateQuiz();
    }

    public void Exit()
    {
        CurrentQuizList?.Clear();
    }
}