using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public class Coin : MonoBehaviour
    {
        private CoinCollectionManager m_coinCollectionManager;

        private void Start()
        {
            m_coinCollectionManager = FindObjectOfType<CoinCollectionManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                m_coinCollectionManager.AddCoin();
                gameObject.SetActive(false);
            }
        }
    }
}

