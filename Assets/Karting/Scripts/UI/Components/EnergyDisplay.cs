using System.Collections;
using Karting.Config;
using Karting.Data;
using Karting.UI.Core;
using Karting.UI.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Karting.UI.Components
{
    public class EnergyDisplay : UIComponent
    {
        [SerializeField] private TMP_Text _energyText;
        [SerializeField] private Button _buyEnergyButton;

        private void Start()
        {
            DisplayEnergy();
            SaveData.OnEnergyConsumed += DisplayEnergy;
            SaveData.OnEnergyRefilled += DisplayEnergy;
            _buyEnergyButton.onClick.AddListener(ShowBuyEnergyPopup);
            StartCoroutine(RefillEnergy());
        }

        protected override void OnShow()
        {
            DisplayEnergy();
        }

        private void DisplayEnergy()
        {
            var saveData = SaveData.Load();
            _energyText.text = $"{saveData.RemainingEnergy}/{ConfigManager.Instance.EnergyConfig.MaxEnergy}";
        }

        private void ShowBuyEnergyPopup()
        {
            UIManager.Instance.ShowPopup<BuyEnergyPopup>();
        }

        private IEnumerator RefillEnergy()
        {
            while (true)
            {
                var refillSeconds = ConfigManager.Instance.EnergyConfig.EnergyRefillRateMs / 1000;
                yield return new WaitForSeconds(refillSeconds);
                var saveData = SaveData.Load();
                saveData.RefillEnergy();
            }
        }
    }
}