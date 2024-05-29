using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenuCanvas;
    [SerializeField]
    GameObject ShopCanvas;

    void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(OpenShop);
    }

    void OpenShop()
    {
        MainMenuCanvas.SetActive(false);
        ShopCanvas.SetActive(true);
    }
}
