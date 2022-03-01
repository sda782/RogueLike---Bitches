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
        itemIndex.Add(new Item(nextId++, "name0", 0, null, true));
        itemIndex.Add(new Item(nextId++, "name1", 0, null, true));
        itemIndex.Add(new Item(nextId++, "name2", 0, null, true));
    }
    public static List<Item> GetAllItems()
    {
        return new List<Item>(itemIndex);
    }
    public static Item GetItemById(int id)
    {
        return itemIndex.Find(i => i.Id == id);
    }
}
