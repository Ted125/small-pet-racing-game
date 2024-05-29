using KartGame.KartSystems;
using KartGame.UI;
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
        [SerializeField]
        private Sprite m_itemIcon;

        public void UseItem()
        {
            int randPoint = Random.Range(0, m_teleportPoints.Length);
            m_player.transform.position = m_teleportPoints[randPoint].position;
            FindObjectOfType<ItemUIHandle>().OnItemUsed();
        }

        public void SetupIcon()
        {
            FindObjectOfType<ItemUIHandle>().SetupUI(m_itemIcon);
        }
    }
}

