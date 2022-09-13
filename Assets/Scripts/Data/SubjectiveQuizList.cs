using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SubjectiveQuizList",menuName = "Data/SubjectiveQuizList")]
    public class SubjectiveQuizList : ScriptableObject
    {
        //public QuizList TargetData;
        public List<SubjectiveQuiz> LolQuizzes;
        public List<SubjectiveQuiz> OverwatchQuizzes;
        public List<SubjectiveQuiz> MapleQuizzes;
        public List<SubjectiveQuiz> TekkenQuizzes;
        public List<SubjectiveQuiz> SteamQuizzes;
        public List<SubjectiveQuiz> HearthStoneQuizzes;
        public List<SubjectiveQuiz> MinecraftQuizzes;
        public List<SubjectiveQuiz> ValorantQuizzes;

        public List<SubjectiveQuiz> GetCategoryQuizList(QuizCategory category,int length)
        {
            var result = new List<SubjectiveQuiz>();
            List<SubjectiveQuiz> targetList = new List<SubjectiveQuiz>();
            switch (category)
            {
                case QuizCategory.LOL:
                    targetList = LolQuizzes;
                    break;
                case QuizCategory.OVERWATCH:
                    targetList = OverwatchQuizzes;
                    break;
                case QuizCategory.MAPLESTORY:
                    targetList = MapleQuizzes;
                    break;
                case QuizCategory.TEKKEN:
                    targetList = TekkenQuizzes;
                    break;
                case QuizCategory.STEAM:
                    targetList = SteamQuizzes;
                    break;
                case QuizCategory.HEARTHSTONE:
                    targetList = HearthStoneQuizzes;
                    break;
                case QuizCategory.MINECRAFT:
                    targetList = MinecraftQuizzes;
                    break;
                case QuizCategory.VALOLANT:
                    targetList = ValorantQuizzes;
                    break;
            }
            if (targetList.Count <= length)
            {
                return targetList.GetRange(0,targetList.Count);
            }
            while (result.Count < length)
            {
                var selectedQuiz = targetList[Random.Range(0, targetList.Count)];
                if (!result.Contains(selectedQuiz)) {
                    result.Add(selectedQuiz);
                }
            }
            return result;
        }
    }
}