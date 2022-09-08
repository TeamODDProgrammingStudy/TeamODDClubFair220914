
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SubjectiveQuizListWithDifficulty",menuName = "Data/SubjectiveQuizListWithDifficulty")]
    public class SubjectiveQuizListWithDifficulty : ScriptableObject
    {
        public SubjectiveQuizList Difficult;
        public SubjectiveQuizList Normal;
        public SubjectiveQuizList Easy;

        public List<SubjectiveQuiz> GetCategoryQuizListWithDifficulty(QuizCategory category,int length, int difficulty)
        {
            SubjectiveQuizList target = Easy;
            switch (difficulty)
            {
                case 1:
                    target = Easy;
                    break;
                case 2:
                    target = Normal;
                    break;
                case 3:
                    target = Difficult;
                    break;
            }
            return target.GetCategoryQuizList(category, length);
        }
    }
}