using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject iventoryMenu;
    [SerializeField] private List<ItemDatabase> itemList;
    [SerializeField] private Image previewHood;
    [SerializeField] private Image previewBody;
    [SerializeField] private Image previewFace;

    [Space(10)]
    [Header("Player Variables")]
    [SerializeField] private SpriteRenderer playerHood;
    [SerializeField] private SpriteRenderer playerBody;
    [SerializeField] private SpriteRenderer playerFace;
    private void Start()
    {
        GameEvents.instance.BuyItem += AddToIventory;
        GameEvents.instance.SellItem += RemoveFromIventory;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IventoryOpenClsoe();
        }
    }

    void IventoryOpenClsoe()
    {
        iventoryMenu.SetActive(!iventoryMenu.activeSelf);
        previewFace.sprite = playerFace.sprite;
        previewBody.sprite = playerBody.sprite;
        previewHood.sprite = playerHood.sprite;
    }

    public void ChangeHead(ItemIventory itemIventory)
    {
        previewHood.sprite = itemIventory.GetItemDatabase().itemSprite;
    }
    public void ChangeBody(ItemIventory itemIventory)
    {
        previewBody.sprite = itemIventory.GetItemDatabase().itemSprite;
    }
    public void ChangeFace(ItemIventory itemIventory)
    {
        previewFace.sprite = itemIventory.GetItemDatabase().itemSprite;
    }

    public void ConfirmChanges()
    {
        playerHood.sprite = previewHood.sprite;
        playerFace.sprite = previewFace.sprite;
        playerBody.sprite = previewBody.sprite;
        iventoryMenu.SetActive(false);
    }

    void AddToIventory(ItemDatabase item)
    {
        itemList.Add(item);
    }
    void RemoveFromIventory(ItemDatabase item)
    {
        if (itemList.Contains(item))
        {
            itemList.Remove(item);
        }
    }
}
