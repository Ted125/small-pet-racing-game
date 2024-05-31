using Karting.Data;
using Karting.UI.Core;
using Karting.UI.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Karting.UI.Components
{
    public class GemDisplay : UIComponent
    {
        [SerializeField] private TMP_Text _gemText;
        [SerializeField] private Button _buyGemsButton;

        private void Start()
        {
            DisplayGems();
            SaveData.OnGemsAdded += DisplayGems;
            SaveData.OnGemsUsed += DisplayGems;
            _buyGemsButton.onClick.AddListener(ShowGemsShopPopup);
        }

        protected override void OnShow()
        {
            DisplayGems();
        }

        private void DisplayGems()
        {
            var saveData = SaveData.Load();
            _gemText.text = saveData.Gems.ToString();
        }

        private void ShowGemsShopPopup()
        {
            UIManager.Instance.ShowPopup<GemsShopPopup>();
        }
    }
}