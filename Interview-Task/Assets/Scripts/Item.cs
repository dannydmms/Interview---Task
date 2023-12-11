using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDatabase itemBase;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject confirmMenu;

    void Start()
    {
        GetComponent<Image>().sprite = itemBase.itemSprite;
        nameText.text = itemBase.itemName;
        priceText.text = itemBase.itemBuyCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
