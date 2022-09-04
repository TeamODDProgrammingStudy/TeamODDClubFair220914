using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerPanel : Window
{
    public TextMeshProUGUI AdditiveText;
    public TextMeshProUGUI AnswerText;
    public TextMeshProUGUI AnswerDescriptionText;
    [TextArea] public string SuccessText = "";
    [TextArea] public string FailedText = "";

    public void Init(int answer,string answerDescriptionText)
    {
        //수정을 위해 아래와 같이 작성
        AnswerDescriptionText.text = $"{answerDescriptionText}" ;
        AnswerText.text = $"정답은 <color=red>{answer}번</color> 입니다.";
        base.Open();
    }
    public void Success(int answer,string answerDescriptionText,int remainQuiz)
    {
        AdditiveText.text = SuccessText;
        Init(answer,answerDescriptionText);
    }

    public void Failed(int answer,string answerDescriptionText,int remainQuiz)
    {
        AdditiveText.text = FailedText;
        Init(answer,answerDescriptionText);
    }
    public void OnNextButtonClicked()
    {
        Close();
    }

    public void OnMainButtonClicked()
    {
        GameManager.Current.ClearPlayerData();
        Close();
    }
}
