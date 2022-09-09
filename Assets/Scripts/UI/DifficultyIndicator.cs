using System;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DifficultyIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _difficultyText;
        public void UpdateDifficulty()
        {
            var targetText = "쉬움";
            switch (GameManager.Current.CurrentPlayerDifficulty)
            {
                case 1:
                    targetText = "쉬움";
                    break;
                case 2:
                    targetText = "보통";
                    break;
                case 3:
                    targetText = "어려움";
                    break;
            }
            _difficultyText.text = "현재 난이도\n<color=red>" + targetText;
        }
    }
}