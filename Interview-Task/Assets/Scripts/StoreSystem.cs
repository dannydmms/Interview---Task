using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreSystem : MonoBehaviour
{
    [SerializeField] private int currentMoney = 9999;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private List<GameObject> allItemSellStore = new List<GameObject>();
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private int helpTimer = 5;
    private void Start()
    {
        moneyText.text = currentMoney.ToString();
        StartCoroutine(HelpMenu());
    }
    /// <summary>
    /// check if player have money enought to buy the current item
    /// </summary> 
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
    /// <summary>
    /// sell the current item
    /// </summary>
    public void SellItem(Item itemDatabase)
    {
        currentMoney += itemDatabase.GetItemDatabase().itemSellCost;
        moneyText.text = currentMoney.ToString();
        itemDatabase.SetInInventory(false);
        GameEvents.instance.OnSellItem(itemDatabase);
    }

    /// <summary>
    /// open the store to sell item
    /// </summary>
    public void OpenSelltore()
    {
        foreach (var item in allItemSellStore)
        {
            item.gameObject.SetActive(false);
        }
        GameEvents.instance.OnOpenSellStore();
    }
    /// <summary>
    /// open the store to buy item
    /// </summary>
    public void OpenBuyStore()
    {
        foreach (var item in allItemSellStore)
        {
            item.gameObject.SetActive(true);
        }
        GameEvents.instance.OnOpenBuyStore();
    }
    /// <summary>
    /// open the help menu
    /// </summary>
    public void OpenHelpMenu()
    {
        helpMenu.SetActive(true);
        StartCoroutine(HelpMenu());
    }
    IEnumerator HelpMenu()
    {
        yield return new WaitForSeconds(helpTimer);
        helpMenu.SetActive(false);

    }
}
