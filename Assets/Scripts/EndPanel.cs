using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanel : Window
{
    public TextMeshProUGUI ScoreText;

    public void Init()
    {
        ScoreText.text = $"당신의 점수는 <color=red>{GameManager.Current.CurrentPlayerPoint}</color>점 입니다.";
        Open();
    }
    public void ReturnToMainMenu()
    {
        GameManager.Current.ClearPlayerData();
        Close();
    }
}
