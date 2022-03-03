using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private PlayerInventory inventory;
    private List<GameObject> items;
    void Start()
    {
        items = new List<GameObject>();
        inventory = GameObject.Find("InvetoryManager").GetComponent<PlayerInventory>();
    }

    public void PickUp()
    {
        if (items.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject i = items[0];
                inventory.addToInventory(i.name.Substring(2));
                items.Remove(i);
                Destroy(i);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag.ToLower())
        {
            case "item":
                items.Add(col.gameObject);
                break;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.tag.ToLower())
        {
            case "item":
                items.Remove(col.gameObject);
                break;
        }
    }
}
