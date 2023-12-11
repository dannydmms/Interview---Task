using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject iventoryMenu;
    [SerializeField] private List<ItemDatabase> itemList;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            IventoryOpenClsoe();
        }
    }

    void IventoryOpenClsoe()
    {
        iventoryMenu.SetActive(!iventoryMenu.activeSelf);
    }
}
