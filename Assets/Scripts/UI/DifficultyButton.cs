using Managers;
using UnityEngine;

namespace UI
{
    public class DifficultyButton : MonoBehaviour
    {
        [SerializeField]private int _difficulty = 1;

        public void OnClick()
        {
            GameManager.Current.StartGame(_difficulty);
        }
    }
}
