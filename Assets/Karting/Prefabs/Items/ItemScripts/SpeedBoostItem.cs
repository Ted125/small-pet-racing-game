using KartGame.Items;
using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KartGame.KartSystems.ArcadeKart;

namespace KartGame.Items
{
    public class SpeedBoostItem : MonoBehaviour, IItemUse
    {
        [SerializeField]
        private ArcadeKart m_player;
        [SerializeField]
        private float m_effectDuration;

        [SerializeField]
        private Stats boostedStatsAddition;
        public void UseItem()
        {
            StartCoroutine(SpeedBoostRoutine());
        }

        private IEnumerator SpeedBoostRoutine()
        {
            var originalStats = m_player.baseStats;
            m_player.baseStats = m_player.baseStats + boostedStatsAddition;

            yield return new WaitForSeconds(m_effectDuration);

            m_player.baseStats = originalStats;
        }
    }
}

