using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class CoinCollectionManager : MonoBehaviour
    {
        [SerializeField]
        public  int m_coinCount;
        [SerializeField]
        private TextMeshProUGUI m_coinCountText;
        [SerializeField]
        private AudioSource m_audioSource;

        public void AddCoin()
        {
            m_coinCount++;
            m_audioSource.Play();
            m_coinCountText.text = m_coinCount.ToString();
        }
    }


