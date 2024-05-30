using Karting.UI.Screens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [SerializeField]
    MenuScreen menuScript;

    [SerializeField]
    TMP_Text CartName;

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
        UpdateUI();
    }

    void backToMainMenu()
    {
        MainMenuScreen.SetActive(true);
        ShopScreen.SetActive(false);
        menuScript.ChangeCart(menuScript.currentSelectedCartID);
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
        menuScript.currentSelectedCartID = selectCounter;
        UpdateUI();
    }

    void BuyCart()
    {
        PlayerPrefs.SetInt("OWNED_CART_" + selectCounter, 1);
        PlayerPrefs.Save();
        UpdateUI();
    }

    void UpdateUI()
    {
        menuScript.ChangeCart(selectCounter);
        CartData data = CartDataManager.GetInstance().carts[selectCounter];
        CartName.text = data.cartName;
        SpeedSlider.minValue = 30;
        SpeedSlider.maxValue = 150;
        SpeedSlider.value = data.topSpeed;

        AccelerationSlider.minValue = 1;
        AccelerationSlider.maxValue = 20;
        AccelerationSlider.value = data.acceleration;

        buyCartButton.gameObject.SetActive(false);
        selectCartButton.gameObject.SetActive(false);
        SelectedCartText.gameObject.SetActive(false);

        if (menuScript.currentSelectedCartID == selectCounter)
            SelectedCartText.gameObject.SetActive(true);
        else if (PlayerPrefs.GetInt("OWNED_CART_" + selectCounter) == 1)
            selectCartButton.gameObject.SetActive(true);
        else
        {
            buyCartButton.gameObject.SetActive(true);
            buyCartButton.GetComponentInChildren<TMP_Text>().text = data.price.ToString();
        }

    }

}
