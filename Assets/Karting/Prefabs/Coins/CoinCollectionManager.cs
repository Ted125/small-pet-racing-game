using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KartGame.Items
{
    public class CoinCollectionManager : MonoBehaviour
    {
        [SerializeField]
        private int m_coinCount;
        [SerializeField]
        private TextMeshProUGUI m_coinCountText;

        public void AddCoin()
        {
            m_coinCount++;
            m_coinCountText.text = m_coinCount.ToString();
        }
    }
}

