using KartGame.Items;
using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.AI
{
    public class JumpBoostItem : MonoBehaviour, IItemUse
    {
        [SerializeField]
        private ArcadeKart m_player;
        [SerializeField]
        private float m_jumpForce;

        private Rigidbody m_playerRb;

        private void Start()
        {
            m_playerRb = m_player.GetComponent<Rigidbody>();
        }
        public void UseItem()
        {
            m_playerRb.AddForce(new Vector3(0, m_jumpForce, 0), ForceMode.VelocityChange);
        }
    }
}

