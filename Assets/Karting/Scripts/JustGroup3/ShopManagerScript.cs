using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField]
    Button selectLeftButton;
    [SerializeField]
    Button selectRightButton;
    [SerializeField]
    Button backButton;
    [SerializeField]
    Button selectCartButton;
    [SerializeField]
    Button buyCartButton;
    [SerializeField]
    GameObject SelectedCartText;

    [SerializeField]
    Slider SpeedSlider;

    [SerializeField]
    Slider AccelerationSlider;


    [SerializeField]
    GameObject ShopScreen;

    [SerializeField]
    GameObject MainMenuScreen;

    List<CartData> cartData;

    int selectCounter;

    void Awake()
    {
        backButton.onClick.AddListener(backToMainMenu);
        selectLeftButton.onClick.AddListener(selectLeft);
        selectRightButton.onClick.AddListener(selectRight);
        selectCartButton.onClick.AddListener(SelectCart);
        buyCartButton.onClick.AddListener(BuyCart);
        cartData = CartDataManager.GetInstance().carts;
    }

    void backToMainMenu()
    {
        MainMenuScreen.SetActive(true);
        ShopScreen.SetActive(false);
    }

    void selectRight()
    {
        selectCounter++;
        if (selectCounter >= cartData.Count)
            selectCounter = 0;
        UpdateUI();
    }

    void selectLeft()
    {
        selectCounter--;
        if (selectCounter < 0)
            selectCounter = cartData.Count - 1;
        UpdateUI();
    }

    void SelectCart()
    {
        PlayerPrefs.SetInt("CART_ID", selectCounter);
        UpdateUI();
    }

    void BuyCart()
    {
        PlayerPrefs.SetInt("OWNED_CART_" + selectCounter, 1);
        UpdateUI();
    }

    void UpdateUI()
    {
        SpawnCart();
    }

    void SpawnCart()
    {

    }
}
