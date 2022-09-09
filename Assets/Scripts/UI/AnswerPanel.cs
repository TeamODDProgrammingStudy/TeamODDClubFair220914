using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AnswerPanel : Window
    {
        public TextMeshProUGUI PlayerAnswerDescriptionText;
        public TextMeshProUGUI AnswerDescriptionText;
        public void Init(string currentQuizAnswer,string playerAnswer = "")
        {
            AnswerDescriptionText.text = currentQuizAnswer;
            PlayerAnswerDescriptionText.text = playerAnswer;
            base.Open();
        }


    }
}
