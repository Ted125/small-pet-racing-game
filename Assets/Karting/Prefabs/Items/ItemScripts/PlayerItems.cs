using KartGame.Items;
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
            int randomItemIndex = Random.Range(0, availableItems.Count - 1);

            currentHeldItem = availableItems[randomItemIndex];
        }
    }
}

