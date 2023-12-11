using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action<Item> BuyItem;
    public void OnBuyItem(Item item)
    {
        if (BuyItem != null)
        {
            BuyItem(item);
        }
    }

    public event Action<Item> SellItem;
    public void OnSellItem(Item item)
    {
        if(SellItem != null)
        {
            SellItem(item);
        }
    }

    public event Action OpenSellStore;
    public void OnOpenSellStore()
    {
        if(OpenSellStore != null)
        {
            OpenSellStore();
        }
    }
    public event Action OpenBuyStore;
    public void OnOpenBuyStore()
    {
        if (OpenBuyStore != null)
        {
            OpenBuyStore();
        }
    }

}
