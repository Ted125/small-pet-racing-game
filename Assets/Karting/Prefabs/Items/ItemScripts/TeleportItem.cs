using KartGame.KartSystems;
using KartGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public class TeleportItem : MonoBehaviour, IItemUse
    {
        private List<Transform> m_teleportPoints = new List<Transform>();
        [SerializeField]
        private ArcadeKart m_player;
        [SerializeField]
        private Sprite m_itemIcon;

        private void Start()
        {
            GameObject[] tpPoints;

            tpPoints = GameObject.FindGameObjectsWithTag("TeleportPoint");

            for (int i = 0; i < tpPoints.Length; i++)
            {
                m_teleportPoints.Add(tpPoints[i].transform);
            }

        }

        public void UseItem()
        {
            int randPoint = Random.Range(0, m_teleportPoints.Count);
            m_player.transform.position = m_teleportPoints[randPoint].position;
            FindObjectOfType<ItemUIHandle>().OnItemUsed();
        }

        public void SetupIcon()
        {
            FindObjectOfType<ItemUIHandle>().SetupUI(m_itemIcon);
        }
    }
}

