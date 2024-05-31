using System.Collections;
using Karting.Config;
using Karting.Data;
using Karting.UI.Core;
using TMPro;
using UnityEngine;

namespace Karting.UI.Components
{
    public class EnergyDisplay : UIComponent
    {
        [SerializeField] private TMP_Text _energyText;

        private void Start()
        {
            DisplayEnergy();
            SaveData.OnEnergyConsumed += DisplayEnergy;
            SaveData.OnEnergyRefilled += DisplayEnergy;
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