using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndPanel : Window
    {
        [TextArea][SerializeField] private string _successText;
        [TextArea][SerializeField] private string _failedText;
        [TextArea][SerializeField] private string _finalText;
        public TextMeshProUGUI ScoreText;
        public Button GoToNextLevelButton;

        public void Init()
        {
            Open();
            if (GameManager.Current.CurrentPlayerPoint <= 0)
            {
                GoToNextLevelButton.gameObject.SetActive(false);
                ScoreText.text = _failedText;
                return;
            }
            if (GameManager.Current.CurrentPlayerDifficulty >=3)
            {
                GoToNextLevelButton.gameObject.SetActive(false);
                ScoreText.text = _finalText;
                return;
            }
            GoToNextLevelButton.gameObject.SetActive(true);
            ScoreText.text = _successText;
        }

        public void GoToNextLevel()
        {
            GameManager.Current.GoToNextLevel();
            Close();
        }
        public void ReturnToMainMenu()
        {
            GameManager.Current.ClearPlayerData();
            Close();
        }
    }
}
