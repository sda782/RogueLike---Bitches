using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private PlayerInventory inventory;
    private LootManager looty;
    private List<GameObject> items;
    void Start()
    {
        items = new List<GameObject>();
        inventory = GameObject.Find("InvetoryManager").GetComponent<PlayerInventory>();
        looty = GameObject.Find("LootContainer").GetComponent<LootManager>();
    }

    public void PickUp()
    {
        if (items.Count > 0)
        {
            GameObject i = items[0];
            switch (i.tag.ToLower())
            {
                case "item":
                    inventory.addToInventory(i.name.Substring(2));
                    break;
                case "chest":
                    looty.GenChestLoot(i.transform);
                    break;
            }
            items.Remove(i);
            Destroy(i);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag.ToLower())
        {
            case "item":
                items.Add(col.gameObject);
                break;
            case "chest":
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
            case "chest":
                items.Remove(col.gameObject);
                break;
        }
    }
}
