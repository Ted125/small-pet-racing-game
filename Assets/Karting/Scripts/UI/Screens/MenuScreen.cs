using Karting.UI.Core;
using Karting.UI.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Karting.UI.Screens
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _raceButton;
        [SerializeField] private Button _leaderboardButton;

        private void Start()
        {
            _leaderboardButton.onClick.AddListener(ShowLeaderboardPopup);
            _raceButton.onClick.AddListener(LoadRaceScene);
            ShowWelcomePopup();
        }

        private void ShowWelcomePopup()
        {
            UIManager.Instance.ShowPopup<WelcomePopup>();
        }

        private void ShowLeaderboardPopup()
        {
            UIManager.Instance.ShowPopup<LeaderboardPopup>();
        }

        private void LoadRaceScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}