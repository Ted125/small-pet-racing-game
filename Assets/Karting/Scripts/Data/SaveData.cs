using System;
using Karting.Config;
using UnityEngine;
using UnityEngine.Events;

namespace Karting.Data
{
    [Serializable]
    public sealed class SaveData
    {
        public string PlayerName = $"Guest-{Guid.NewGuid().ToString()[^4..]}";
        public bool HasPlayerRenamed = false;
        public int RemainingEnergy = ConfigManager.Instance.EnergyConfig.MaxEnergy;
        public DateTime LastEnergyRefill;
        public int Gems = 0;

        public static UnityAction OnPlayerNameUpdated;
        public static UnityAction OnEnergyConsumed;
        public static UnityAction OnEnergyRefilled;
        public static UnityAction OnGemsAdded;
        public static UnityAction OnGemsUsed;

        private const string SAVE_DATA_FILE_NAME = "karting.save";

        public static SaveData Load()
        {
            var saveDataJson = PlayerPrefs.GetString(SAVE_DATA_FILE_NAME);

            if (string.IsNullOrEmpty(saveDataJson))
            {
                var newSaveData = CreateInitialSaveData();
                newSaveData.Save();
                return newSaveData;
            }

            return JsonUtility.FromJson<SaveData>(saveDataJson);
        }

        private static SaveData CreateInitialSaveData()
        {
            return new SaveData();
        }

        public void SetPlayerName(string playerName)
        {
            PlayerName = playerName;
            HasPlayerRenamed = true;
            Save();
            OnPlayerNameUpdated?.Invoke();
        }

        public void ConsumeEnergy(int amount)
        {
            RemainingEnergy = Mathf.Clamp(RemainingEnergy - amount, 0, ConfigManager.Instance.EnergyConfig.MaxEnergy);
            LastEnergyRefill = DateTime.UtcNow;
            Save();
            OnEnergyConsumed?.Invoke();
        }

        public void RefillEnergy()
        {
            RemainingEnergy = Mathf.Clamp(RemainingEnergy + ConfigManager.Instance.EnergyConfig.EnergyRefillAmount, 0, ConfigManager.Instance.EnergyConfig.MaxEnergy);
            LastEnergyRefill = DateTime.UtcNow;
            Save();
            OnEnergyRefilled?.Invoke();
        }

        public void AddGems(int amount)
        {
            Gems += amount;
            Save();
            OnGemsAdded?.Invoke();
        }

        public void UseGems(int amount)
        {
            Gems -= amount;
            Save();
            OnGemsUsed?.Invoke();
        }

        public void Save()
        {
            var saveDataJson = JsonUtility.ToJson(this);
            Debug.Log($"New save data: {saveDataJson}");
            PlayerPrefs.SetString(SAVE_DATA_FILE_NAME, saveDataJson);
        }
    }
}