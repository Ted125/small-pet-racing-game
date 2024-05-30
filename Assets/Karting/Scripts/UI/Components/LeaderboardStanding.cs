using Karting.UI.Core;
using TMPro;
using UnityEngine;

namespace Karting.UI.Components
{
    public class LeaderboardStanding : UIComponent
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _score;

        public void Render(int rank, string playerName, int score)
        {
            _rank.text = rank.ToString();
            _playerName.text = playerName;
            _score.text = score.ToString("D2");
        }
    }
}