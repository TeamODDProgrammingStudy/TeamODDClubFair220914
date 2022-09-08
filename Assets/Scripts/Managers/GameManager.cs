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
        public int DefaultQuizLength = 9;
        public int CurrentPlayerPoint = 0;
        public QuizCategory CurrentCategory = QuizCategory.LOL;
        [SerializeField] private SubjectiveQuizCreator _subjectiveQuizCreator;
        [SerializeField] private SubjectiveQuizListWithDifficulty _subjectiveQuizListWithDifficulty;
        public void Start() {
            Current = this;
        }
        public void ClearPlayerData()
        {
            CurrentPlayerPoint = 0;
            CurrentCategory = QuizCategory.LOL;
        }

        public void StartGame(int difficulty = 1)
        {
            difficulty = (difficulty < 1 ? 1 : difficulty) > 3 ? 3 : difficulty;
            //var quizList = QuizLists.GetCategoryQuizList(category,DefaultQuizLength);
            var subjectiveQuiz = _subjectiveQuizListWithDifficulty
                .GetCategoryQuizListWithDifficulty(CurrentCategory, DefaultQuizLength,difficulty);
            _subjectiveQuizCreator.SetQuizList(subjectiveQuiz);
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