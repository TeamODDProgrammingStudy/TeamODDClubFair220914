using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Current;
        public int DefaultQuizLength = 1;
        public int CurrentPlayerPoint = 0;
        public int CurrentPlayerDifficulty = 1;
        public QuizCategory CurrentCategory = QuizCategory.LOL;
        [SerializeField] private SubjectiveQuizCreator _subjectiveQuizCreator;
        [SerializeField] private SubjectiveQuizListWithDifficulty _subjectiveQuizListWithDifficulty;
        public void Start() {
            Current = this;
        }
        public void ClearPlayerData()
        {
            CurrentPlayerPoint = 0;
            CurrentPlayerDifficulty = 1;
            CurrentCategory = QuizCategory.LOL;
        }

        public void StartGame()
        {
            var subjectiveQuiz = _subjectiveQuizListWithDifficulty
                .GetCategoryQuizListWithDifficulty(CurrentCategory, DefaultQuizLength,CurrentPlayerDifficulty);
            _subjectiveQuizCreator.SetQuizList(subjectiveQuiz);
        }

        public void SetDifficulty(int difficulty)
        {
            CurrentPlayerDifficulty = difficulty;
        }
        public void GoToNextLevel()
        {
            CurrentPlayerPoint = 0;
            CurrentCategory = QuizCategory.LOL;
            CurrentPlayerDifficulty++;
        }
        public void SelectCategory(QuizCategory category)
        {
            CurrentCategory = category;
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
}