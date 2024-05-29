using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public class CoinCollectionManager : MonoBehaviour
    {
        [SerializeField]
        private int m_coinCount;

        public void AddCoin()
        {
            m_coinCount++;
        }
    }
}

