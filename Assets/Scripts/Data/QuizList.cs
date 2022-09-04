using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data
{
    [CreateAssetMenu(fileName = "QuizList",menuName = "Data/QuizList")]
    public class QuizList : ScriptableObject
    {
        public List<Quiz> LolQuizzes;
        public List<Quiz> OverwatchQuizzes;
        public List<Quiz> MapleQuizzes;
        public List<Quiz> TekkenQuizzes;
        public List<Quiz> SteamQuizzes;
        public List<Quiz> HearthStoneQuizzes;
        public List<Quiz> MinecraftQuizzes;
        public void OnValidate()
        {
            
        }

        public List<Quiz> GetCategoryQuizList(QuizCategory category,int length)
        {
            var result = new List<Quiz>();
            List<Quiz> targetList = new List<Quiz>();
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
            }
            if (targetList.Count <= length)
            {
                return targetList;
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