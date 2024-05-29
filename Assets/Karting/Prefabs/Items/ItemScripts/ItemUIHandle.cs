using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KartGame.UI
{
    public class ItemUIHandle : MonoBehaviour
    {
        [SerializeField]
        private Image m_image;
        [SerializeField]
        private GameObject m_container;

        private void Start()
        {
            m_container.SetActive(false);
        }

        public void SetupUI(Sprite image)
        {
            m_image.overrideSprite = image;
            TurnOnUI();
        }

        public void TurnOnUI()
        {
            if(m_image != null)
            {
                m_container.SetActive(true);
            }
        }

        public void OnItemUsed()
        {
            m_container.SetActive(false);
        }
    }
}

