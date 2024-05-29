using Karting.Config;
using Karting.Data;
using Karting.UI.Core;
using Karting.UI.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Karting.UI.Screens
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private Button _raceButton;
        [SerializeField] private Button _leaderboardButton;

        private void Start()
        {
            _leaderboardButton.onClick.AddListener(ShowLeaderboardPopup);
            _raceButton.onClick.AddListener(LoadRaceScene);
            DisplayPlayerName();
            ShowWelcomePopup();
            SaveData.OnPlayerNameUpdated += DisplayPlayerName;
        }

        private void ShowWelcomePopup()
        {
            var saveData = SaveData.Load();

            if (!saveData.HasPlayerRenamed)
            {
                UIManager.Instance.ShowPopup<WelcomePopup>();
            }
        }

        private void DisplayPlayerName()
        {
            var saveData = SaveData.Load();
            _playerName.text = saveData.PlayerName;
        }

        private void ShowLeaderboardPopup()
        {
            UIManager.Instance.ShowPopup<LeaderboardPopup>();
        }

        private void LoadRaceScene()
        {
            var saveData = SaveData.Load();
            var energyCost = ConfigManager.Instance.EnergyConfig.RaceEnergyCost;

            if (saveData.RemainingEnergy < energyCost)
            {
                return;
            }

            saveData.ConsumeEnergy(energyCost);
            SceneManager.LoadScene("MainScene");
        }
    }
}