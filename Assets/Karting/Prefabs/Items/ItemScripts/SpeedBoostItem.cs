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
        private Stats boostedStatsAddition;
        public void UseItem()
        {
            m_player.baseStats = m_player.baseStats + boostedStatsAddition;
        }
    }
}

