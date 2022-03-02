using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static List<Item> itemIndex;
    private static int nextId = 0;
    void Awake()
    {
        itemIndex = new List<Item>();
        itemIndex.Add(new Item(nextId++, "A fools sword", 0, null, true));
        itemIndex.Add(new Item(nextId++, "Apprentice hammer", 0, null, true));
        itemIndex.Add(new Item(nextId++, "The elder bow", 0, null, true));
    }
    public static List<Item> GetAllItems()
    {
        return itemIndex;
    }
    public static Item GetItemById(int id)
    {
        return itemIndex.Find(i => i.Id == id);
    }
}
