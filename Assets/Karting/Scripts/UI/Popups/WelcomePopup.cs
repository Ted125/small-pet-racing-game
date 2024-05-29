using Karting.Data;
using Karting.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Karting.UI.Popups
{
    public class WelcomePopup : UIPopup
    {
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _submitButton;

        private void Start()
        {
            _submitButton.onClick.AddListener(Submit);
        }

        private void Submit()
        {
            var saveData = SaveData.Load();
            saveData.PlayerName = _nameInputField.text;
            saveData.Save();
            gameObject.SetActive(false);
        }
    }
}