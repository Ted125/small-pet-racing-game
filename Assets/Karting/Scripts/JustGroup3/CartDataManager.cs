using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartDataManager
{
    static CartDataManager Instance;

    public List<CartData> carts;

    public static CartDataManager GetInstance()
    {
        if(Instance == null)
        {
            Instance = new CartDataManager();
            Instance.InitializeData();
        }

        return Instance;
    }


    public void InitializeData()
    {
        carts = new List<CartData>();
        carts.Add(new CartData(0, "gocartstick", 0, 1, Color.white, "Go Kart", 80, 8, 0));
        carts.Add(new CartData(1, "bamboostick", 0, 1, Color.white, "Stick-a-boo", 100, 8, 20));
        carts.Add(new CartData(2, "gocartpanda", 0, 1, Color.white, "Panda Cart", 80, 10, 30));
        carts.Add(new CartData(3, "bamboopanda", 0, 1, Color.white, "Panda Master", 100, 10, 40));

        carts.Add(new CartData(4, "gocartstick", 0, 1, Color.red, "Red Go Kart", 120, 10, 50));
        carts.Add(new CartData(5, "bamboostick", 0, 1, Color.black, "Black Sticks", 120, 12, 60));
        carts.Add(new CartData(6, "gocartpanda", 0, 1, Color.blue, "Blue Panda Cart", 150, 15, 70));
        carts.Add(new CartData(7, "bamboopanda", 1, 5, Color.yellow, "Bright Panda Master", 200, 20, 80));
    }

}