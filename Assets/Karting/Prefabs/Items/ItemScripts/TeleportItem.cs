using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public class TeleportItem : MonoBehaviour, IItemUse
    {
        [SerializeField]
        private Transform[] m_teleportPoints;
        [SerializeField]
        private ArcadeKart m_player;

        public void UseItem()
        {
            int randPoint = Random.Range(0, m_teleportPoints.Length);
            m_player.transform.position = m_teleportPoints[randPoint].position;
        }
    }
}

