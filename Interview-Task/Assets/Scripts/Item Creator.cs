using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item", menuName ="Item")]
public class ItemCreator : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite itemSprite;
    public int itemBuyCost;
    public int itemSellCost;
}
