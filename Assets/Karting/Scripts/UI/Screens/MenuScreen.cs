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
            _raceButton.onClick.AddListener(LoadRaceScene);
            _leaderboardButton.onClick.AddListener(ShowLeaderboardPopup);
        }

        private void LoadRaceScene()
        {
            SceneManager.LoadScene("MainScene");
        }

        private void ShowLeaderboardPopup()
        {
            UIManager.Instance.ShowPopup<LeaderboardPopup>();
        }
    }
}