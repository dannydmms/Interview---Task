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
    /// <summary>
    /// get the item database
    /// </summary>
    public ItemDatabase GetItemDatabase()
    {
        return itemBase;
    }
    /// <summary>
    /// enable the buy button
    /// </summary>
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
    /// <summary>
    /// enable the sell button
    /// </summary>
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
    /// <summary>
    /// return if is in inventoru
    /// </summary>
    /// <returns></returns>
    public bool CheckIsInventory()
    {
        return isInInventory;
    }
    /// <summary>
    /// set if is in the inventory
    /// </summary>
    /// <param name="value"></param>
    public void SetInInventory(bool value)
    {
        isInInventory = value;
    }

}
