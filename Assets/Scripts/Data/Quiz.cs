using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "Quiz",menuName = "Data/Quiz")]
    public class Quiz : ScriptableObject
    {
        public int QuizCode;
        [TextArea]public string Question;
        [TextArea]public string[] Selection;
        public int Answer;
    }
}
