using KartGame.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemViaButton : MonoBehaviour
{
    public void PressCtrl()
    {
        FindObjectOfType<PlayerItems>().UseItem();
    }
}
