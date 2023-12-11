using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIventory : MonoBehaviour
{
    [SerializeField] private ItemDatabase itemBase;

    void Start()
    {
        GetComponent<Image>().sprite = itemBase.itemSprite;
    }

    public ItemDatabase GetItemDatabase()
    {
        return itemBase;
    }
}
