using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject blackout;

    /// <summary>
    /// check if player is on collider to open the store ui
    /// </summary>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                store.SetActive(true);
                blackout.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    /// <summary>
    /// check if player left the store area to close the store ui
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                store.SetActive(false);
                blackout.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    /// <summary>
    /// close store ui
    /// </summary>
    public void CloseStore()
    {
        store.SetActive(false);
        blackout.SetActive(false);
        Time.timeScale = 1;
    }
}
