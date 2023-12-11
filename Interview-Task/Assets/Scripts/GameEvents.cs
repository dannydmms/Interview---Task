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

    public event Action<ItemDatabase> BuyItem;
    public void OnBuyItem(ItemDatabase item)
    {
        if (BuyItem != null)
        {
            BuyItem(item);
        }
    }

    public event Action<ItemDatabase> SellItem;
    public void OnSellItem(ItemDatabase item)
    {
        if(SellItem != null)
        {
            SellItem(item);
        }
    }
    
}
