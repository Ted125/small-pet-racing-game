using Karting.Config;
using Karting.Data;
using Karting.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Karting.UI.Popups
{
    public class BuyEnergyPopup : UIPopup
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private int _gemCost = 5;
        [SerializeField] private int _energyReward = 20;

        private void Start()
        {
            _buyButton.onClick.AddListener(Buy);
        }

        protected override void OnShow()
        {
            RenderBuyButton();
        }

        private void RenderBuyButton()
        {
            var saveData = SaveData.Load();
            var canBuyEnergy = (saveData.Gems >= _gemCost) && (saveData.RemainingEnergy < ConfigManager.Instance.EnergyConfig.MaxEnergy);
            _buyButton.interactable = canBuyEnergy;
        }

        private void Buy()
        {
            var saveData = SaveData.Load();

            if (saveData.Gems >= _gemCost)
            {
                saveData.UseGems(_gemCost);
                saveData.RefillEnergy(_energyReward);
            }

            RenderBuyButton();
        }
    }
}