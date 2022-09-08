using UnityEngine;

namespace UI
{
    public class SettingButton : MonoBehaviour
    {
        [SerializeField] private GameObject _settingInputField;
        public void OnClick()
        {
            _settingInputField.SetActive(!_settingInputField.activeSelf);
        }
    }
}
