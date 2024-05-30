using KartGame.Items;
using KartGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public class PlayerItems : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> availableItems = new List<GameObject>();

        [SerializeField]
        private GameObject currentHeldItem = null;

        public void SetRandomHeldItem()
        {
            int randomItemIndex = Random.Range(0, availableItems.Count);

            currentHeldItem = availableItems[randomItemIndex];

            currentHeldItem.GetComponent<IItemUse>().SetupIcon();
        }

        private void Update()
        {
            if (Input.GetButtonDown("UseItem"))
            {
                UseItem();
                
            }
        }

        public void UseItem()
        {
            if (currentHeldItem != null)
            {
                Debug.Log("Used Item");
                currentHeldItem.GetComponent<IItemUse>().UseItem();
                currentHeldItem = null;
            }
        }
    }
}

