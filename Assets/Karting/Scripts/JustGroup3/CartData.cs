using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartData
{
    public int id;
    public string prefabName;
    public float metallic;
    public int normalMapHeight;
    public Color cartColor;
    public string cartName;
    public float topSpeed;
    public float acceleration;
    public int price;

    public CartData(int p_id, string p_prefabName, float p_metallic, int p_normalMapHeight, Color p_cartColor, 
        string p_cartName, float p_topSpeed, float p_acceleration, int p_price)
    {
        id = p_id;
        prefabName = p_prefabName;
        metallic = p_metallic;
        normalMapHeight = p_normalMapHeight;
        cartColor = p_cartColor;
        cartName = p_cartName;
        topSpeed = p_topSpeed;
        acceleration = p_acceleration;
        price = p_price;
    }
}

