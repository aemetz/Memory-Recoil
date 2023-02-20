using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{

    public int currency;
    public TMP_Text currency_display;
    public Item[] shopItemArray;
    public GameObject[] shopItemPanelsObject;
    public ShopCanvas[] shopItemPanels;
    public Button[] itemPanelButtons;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemArray.Length; i++)
        {
            shopItemPanelsObject[i].SetActive(true);
        }
            currency_display.text = "Coins: " + currency.ToString();
        LoadShopItems();
        CheckCost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCurrency()
    {
        currency++;
        currency_display.text = "Coins: " + currency.ToString();
        CheckCost();
    }

    public void LoadShopItems()
    {
        for(int i=0; i< shopItemArray.Length; i++)
        {
            shopItemPanels[i].title.text = shopItemArray[i].itemTitle;
            shopItemPanels[i].descriptionText.text = shopItemArray[i].itemDescription;
            shopItemPanels[i].costText.text = "Coins: " + shopItemArray[i].itemCost.ToString();
            shopItemPanels[i].itemImage.sprite = shopItemArray[i].image;

        }
    }

    public void CheckCost()
    {
        for (int i = 0; i < shopItemArray.Length; i++)
        {
            if (currency >= shopItemArray[i].itemCost)
            {
                itemPanelButtons[i].interactable = true;
            }
            else
            {
                itemPanelButtons[i].interactable = false;
            }

        }
    }

    public void BuyItem(int slotNumber)
    {
        if(currency >= shopItemArray[slotNumber].itemCost)
        {
            currency -= shopItemArray[slotNumber].itemCost;
            currency_display.text = "Coins: " + currency.ToString();
            CheckCost();
        }
    }
}
