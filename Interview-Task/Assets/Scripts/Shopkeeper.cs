using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject store;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                store.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                store.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void CloseStore()
    {
        store.SetActive(false);
        Time.timeScale = 1;
    }
}
