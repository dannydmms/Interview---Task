using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject blackout;
    [SerializeField] private List<Item> itemList;
    [SerializeField] private Image previewHood;
    [SerializeField] private Image previewBody;
    [SerializeField] private Image previewFace;
    [SerializeField] private List<Item> allItems;
    [Space(10)]
    [Header("Player Variables")]
    [SerializeField] private SpriteRenderer playerHood;
    [SerializeField] private SpriteRenderer playerBody;
    [SerializeField] private SpriteRenderer playerFace;
    private void Start()
    {
        GameEvents.instance.BuyItem += AddToInventory;
        GameEvents.instance.SellItem += RemoveFromInventory;
        GameEvents.instance.OpenSellStore += CurrentItens;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryOpenClsoe();
        }
    }
    void InventoryOpenClsoe()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeSelf);
        blackout.SetActive(!blackout.activeSelf);
        previewFace.sprite = playerFace.sprite;
        previewBody.sprite = playerBody.sprite;
        previewHood.sprite = playerHood.sprite;

        foreach (var item in allItems)
        {
            if (item.CheckIsInventory())
            {
                item.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ChangeHead(Item itemIventory)
    {
        previewHood.sprite = itemIventory.GetItemDatabase().itemSprite;
    }
    public void ChangeBody(Item itemIventory)
    {
        previewBody.sprite = itemIventory.GetItemDatabase().itemSprite;
    }
    public void ChangeFace(Item itemIventory)
    {
        previewFace.sprite = itemIventory.GetItemDatabase().itemSprite;
    }

    public void ConfirmChanges()
    {
        playerHood.sprite = previewHood.sprite;
        playerFace.sprite = previewFace.sprite;
        playerBody.sprite = previewBody.sprite;
        inventoryMenu.SetActive(false);
        blackout.SetActive(false);
    }

    void AddToInventory(Item item)
    {
        if (!itemList.Contains(item))
        {
            itemList.Add(item);
            //item.GetComponent<Button>().interactable = true;
            foreach (var items in allItems)
            {
                if (item.GetItemDatabase().itemID == items.GetItemDatabase().itemID)
                {
                    items.GetComponent<Button>().interactable = true;
                }
            }
        }
    }
    void RemoveFromInventory(Item item)
    {
        if (itemList.Contains(item))
        {
            itemList.Remove(item);
            item.gameObject.SetActive(false);
            foreach (var items in allItems)
            {
                if (item.GetItemDatabase().itemID == items.GetItemDatabase().itemID)
                {
                    items.GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    void CurrentItens()
    {
        foreach (var item in itemList)
        {
            item.gameObject.SetActive(true);
        }
    }
}
