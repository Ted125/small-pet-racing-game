using Karting.Data;
using Karting.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Karting.UI.Components
{
    public class GemsShopItem : UIComponent
    {
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private TMP_Text _itemPriceText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private string _itemName;
        [SerializeField] private float _itemPrice;
        [SerializeField] private int _gemReward;

        private void Start()
        {
            _buyButton.onClick.AddListener(Buy);
        }

        protected override void OnShow()
        {
            DisplayDetails();
        }

        private void DisplayDetails()
        {
            _itemNameText.text = _itemName;
            _itemPriceText.text = $"${_itemPrice.ToString("F2")}";
        }

        private void Buy()
        {
            var saveData = SaveData.Load();
            saveData.AddGems(_gemReward);
        }
    }
}