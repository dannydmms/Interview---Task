using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDatabase itemBase;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject sellButton;
    [SerializeField]private bool isInInventory = false;

    void Start()
    {
        GetComponent<Image>().sprite = itemBase.itemSprite;
        if (nameText != null)
        {
            nameText.text = itemBase.itemName;
        }
        if (priceText != null)
        {
            priceText.text = itemBase.itemBuyCost.ToString();
        }
        GameEvents.instance.OpenSellStore += EnableSellButton;
        GameEvents.instance.OpenBuyStore += EnableBuyButton;
    }
    public ItemDatabase GetItemDatabase()
    {
        return itemBase;
    }
    public void EnableBuyButton()
    {
        if (sellButton != null)
        {
            sellButton.SetActive(false);
        }
        if (buyButton != null)
        {
            buyButton.SetActive(true);
        }
        if (priceText)
        {
            priceText.text = itemBase.itemBuyCost.ToString();
        }
    }
    public void EnableSellButton()
    {
        if (sellButton != null)
        {
            sellButton.SetActive(true);
        }
        if (buyButton != null)
        {
            buyButton.SetActive(false);
        }
        if (priceText != null)
        {
            priceText.text = itemBase.itemSellCost.ToString();
        }
    }
    public bool CheckIsInventory()
    {
        return isInInventory;
    }
    public void SetInInventory(bool value)
    {
        isInInventory = value;
    }

}
