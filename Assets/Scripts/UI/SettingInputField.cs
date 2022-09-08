using System;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SettingInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        private void OnEnable()
        {
            _inputField.text = GameManager.Current.DefaultQuizLength.ToString();
        }

        public void OnValueChanged(string value)
        {
            GameManager.Current.DefaultQuizLength = int.Parse(value);
        }
    }
}