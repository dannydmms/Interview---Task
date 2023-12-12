using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreSystem : MonoBehaviour
{
    [SerializeField] private int currentMoney = 9999;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private List<GameObject> allItemSellStore = new List<GameObject>();

    private void Start()
    {
        moneyText.text = currentMoney.ToString();
    }
    public void BuyItem(Item itemDatabase)
    {
        if (currentMoney > itemDatabase.GetItemDatabase().itemSellCost)
        {
            currentMoney -= itemDatabase.GetItemDatabase().itemBuyCost;
            moneyText.text = currentMoney.ToString();
            itemDatabase.SetInInventory(true);
            GameEvents.instance.OnBuyItem(itemDatabase);
        }
    }
    public void SellItem(Item itemDatabase)
    {
        currentMoney += itemDatabase.GetItemDatabase().itemSellCost;
        moneyText.text = currentMoney.ToString();
        itemDatabase.SetInInventory(false);
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
