using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private PlayerInventory inventory;
    private bool canPickUpItems;
    private GameObject item;
    void Start()
    {
        inventory = GameObject.Find("InvetoryManager").GetComponent<PlayerInventory>();
        canPickUpItems = false;
    }
    void Update()
    {
        if (canPickUpItems && item != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                inventory.addToInventory(item.name.Substring(2));
                Destroy(item);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag.ToLower())
        {
            case "item":
                canPickUpItems = true;
                item = col.gameObject;
                break;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.tag.ToLower())
        {
            case "item":
                canPickUpItems = false;
                item = null;
                break;
        }
    }
}
