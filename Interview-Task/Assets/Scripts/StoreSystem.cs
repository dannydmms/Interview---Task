using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSystem : MonoBehaviour
{
    [SerializeField] private int currentMoney = 9999;
    [SerializeField] private List<GameObject> allItemSellStore = new List<GameObject>();
    public void BuyItem(Item itemDatabase)
    {
        if (currentMoney > itemDatabase.GetItemDatabase().itemSellCost)
        {
            currentMoney -= itemDatabase.GetItemDatabase().itemBuyCost;
            itemDatabase.GetItemDatabase().isInIventory = true;
            GameEvents.instance.OnBuyItem(itemDatabase);
        }
    }
    public void SellItem(Item itemDatabase)
    {
        currentMoney += itemDatabase.GetItemDatabase().itemSellCost;
        itemDatabase.GetItemDatabase().isInIventory = false;
        GameEvents.instance.OnSellItem(itemDatabase);
    }

    public void OpenSelltore()
    {
        foreach (var item in allItemSellStore)
        {
            item.gameObject.SetActive(false);
        }
        GameEvents.instance.OnOpenSellStore();
    }
    public void OpenBuyStore()
    {
        foreach (var item in allItemSellStore)
        {
            item.gameObject.SetActive(true);
        }
        GameEvents.instance.OnOpenBuyStore();
    }
}
