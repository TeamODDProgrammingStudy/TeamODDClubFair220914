using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Current;
    public int DefaultQuizLength = 9;
    public int CurrentPlayerPoint = 0;
    public QuizCategory CurrentCategory = QuizCategory.LOL;
    [SerializeField] private SubjectiveQuizCreator _subjectiveQuizCreator;
    [SerializeField] private SubjectiveQuizList _subjectiveQuizList;
    public void Start() {
        Current = this;
    }
    public void ClearPlayerData()
    {
        CurrentPlayerPoint = 0;
        CurrentCategory = QuizCategory.LOL;
    }

    public void StartGame(QuizCategory category)
    {
        CurrentCategory = category;
        //var quizList = QuizLists.GetCategoryQuizList(category,DefaultQuizLength);
        var subjectiveQuiz = _subjectiveQuizList.GetCategoryQuizList(category, DefaultQuizLength);
        _subjectiveQuizCreator.SetQuizList(subjectiveQuiz);
    }
}
public enum QuizCategory
{
    LOL = 0,
    OVERWATCH = 1,
    MAPLESTORY = 2,
    TEKKEN = 3,
    STEAM = 4,
    HEARTHSTONE = 5,
    MINECRAFT = 6
}
