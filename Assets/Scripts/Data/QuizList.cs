using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "QuizList",menuName = "Data/QuizList")]
    public class QuizList : ScriptableObject
    {
        public List<Quiz> LolQuizzes;
        public List<Quiz> MapleQuizzes;

        public void OnValidate()
        {
            
        }
    }
}