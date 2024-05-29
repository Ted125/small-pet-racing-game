using System;
using UnityEngine;
using UnityEngine.Events;

namespace Karting.Data
{
    [Serializable]
    public sealed class SaveData
    {
        public string PlayerName = $"Guest-{Guid.NewGuid().ToString()[^4..]}";
        public bool HasPlayerRenamed = false;

        public static UnityAction OnPlayerNameUpdated;

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

        public void Save()
        {
            var saveDataJson = JsonUtility.ToJson(this);
            Debug.Log($"New save data: {saveDataJson}");
            PlayerPrefs.SetString(SAVE_DATA_FILE_NAME, saveDataJson);
        }
    }
}