using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour
{
    public int Position = 0;
    public QuizCreator Parent;
    public TextMeshProUGUI AnswerText;
    public Button ThisButton;
    public void Init(string selection)
    {
        ThisButton.interactable = true;
        gameObject.SetActive(true);
        AnswerText.text = selection;
    }

    public void OnClick()
    {
        ThisButton.interactable = false;
        Parent.OnAnswerClicked(Position);
    }
    private void OnValidate()
    {
        ThisButton = GetComponentInChildren<Button>();
        Parent = GetComponentInParent<QuizCreator>();
        AnswerText = GetComponentInChildren<TextMeshProUGUI>();
    }
}