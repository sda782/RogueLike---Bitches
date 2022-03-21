using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private PlayerInventory inventory;
    private LootManager looty;
    private List<GameObject> items;
    [SerializeField]
    private Sprite open_chest;
    [SerializeField]
    private Sprite open_key_chest;
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
                    if (inventory.addToInventory(i.name.Substring(2))) { items.Remove(i); Destroy(i); }
                    break;
                case "chest":
                    looty.GenChestLoot(i.transform);
                    items.Remove(i);
                    i.GetComponent<SpriteRenderer>().sprite = open_chest;
                    i.tag = "Untagged";
                    break;
                case "keychest":
                    looty.GenKeyChestLoot(i.transform);
                    items.Remove(i);
                    i.GetComponent<SpriteRenderer>().sprite = open_key_chest;
                    i.tag = "Untagged";
                    break;
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
            case "chest":
                items.Add(col.gameObject);
                break;
            case "keychest":
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
            case "keychest":
                items.Remove(col.gameObject);
                break;
        }
    }
}
