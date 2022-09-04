using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Quiz
    {
        //public int QuizCode;
        [TextArea]public string Question;
        [TextArea]public string[] Selection;
        public int Answer;
    }
}
