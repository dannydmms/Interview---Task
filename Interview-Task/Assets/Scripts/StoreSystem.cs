using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSystem : MonoBehaviour
{
    [SerializeField] private int currentMoney = 9999;

    public void BuyItem(ItemDatabase itemDatabase)
    {
        if (currentMoney > itemDatabase.itemBuyCost)
        {
            GameEvents.instance.OnBuyItem(itemDatabase);
            currentMoney -= itemDatabase.itemBuyCost;
        }
    }
    public void SellItem(ItemDatabase itemDatabase)
    {
        currentMoney += itemDatabase.itemSellCost;
        GameEvents.instance.OnSellItem(itemDatabase);
    }
}
