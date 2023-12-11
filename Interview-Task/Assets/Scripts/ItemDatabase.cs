using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New item", menuName ="Create Item")]
public class ItemDatabase : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite itemSprite;
    public int itemBuyCost;
    public int itemSellCost;

}
