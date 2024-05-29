using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Items
{
    public interface IItemUse
    {
        public void UseItem();

        public void SetupIcon();
    }

}
