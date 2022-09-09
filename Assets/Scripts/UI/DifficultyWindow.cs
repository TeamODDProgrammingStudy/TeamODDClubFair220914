using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DifficultyWindow : Window
    {
        public Button HardButton;
        public Button MediumButton;
        public Button EasyButton;

        public override void Open()
        {
            base.Open();
            HardButton.interactable = GameManager.Current.CurrentPlayerDifficulty < 3;
            MediumButton.interactable = GameManager.Current.CurrentPlayerDifficulty < 2;
            EasyButton.interactable = GameManager.Current.CurrentPlayerDifficulty < 1;
        }
    }
}
