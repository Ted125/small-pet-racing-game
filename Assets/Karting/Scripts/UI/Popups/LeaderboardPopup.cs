using Karting.UI.Components;
using Karting.UI.Core;
using TMPro;
using UnityEngine;

namespace Karting.UI.Popups
{
    public class LeaderboardPopup : UIPopup
    {
        [SerializeField] private TMP_Text _loadingText;
        [SerializeField] private Transform _standingsParent;
        [SerializeField] private LeaderboardStanding _standingPrefab;

        private dreamloLeaderBoard _dreamlo;

        private void Awake()
        {
            _dreamlo = FindObjectOfType<dreamloLeaderBoard>();
        }

        protected override void OnShow()
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            ClearLeaderboard();
            _loadingText.gameObject.SetActive(true);
            _dreamlo.GetScores(RenderLeaderboard);
        }

        private void ClearLeaderboard()
        {
            foreach (Transform child in _standingsParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void RenderLeaderboard()
        {
            _loadingText.gameObject.SetActive(false);
            var scores = _dreamlo.ToListHighToLow();

            for (var i = 0; i < scores.Count; ++i)
            {
                var rank = i + 1;
                var score = scores[i];
                var standing = Instantiate(_standingPrefab, _standingsParent);
                standing.Render(rank, score.playerName, score.score);
            }
        }

    }
}   