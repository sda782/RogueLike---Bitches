using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static List<Item> itemIndex;
    private static int nextId = 0;
    public enum ItemType { EQUIPMENT, CONSUMABLE, COINS, MISC }
    void Awake()
    {
        itemIndex = new List<Item>();
        getItemsFromJson();

    }
    public static List<Item> GetAllItems()
    {
        return itemIndex;
    }
    public static Item GetItemByName(string name)
    {
        return itemIndex.Find(i => i.Name == name);
    }
    public static List<Item> GetItemsByType(ItemType itemType)
    {
        List<Item> items = new List<Item>();
        items = itemIndex.FindAll(i => i.ItemType.ToLower() == itemType.ToString().ToLower());
        return items;
    }
    private static void getItemsFromJson()
    {
        string jsonstring = Resources.Load<TextAsset>("items").text;
        Items items = (Items)JsonUtility.FromJson(jsonstring, typeof(Items));
        itemIndex = items.items;
        foreach (var item in itemIndex)
        {
            item.Id = nextId++;
            item.SetSprite();
        }
        Debug.Log("Loaded " + items.items.Count + " items from file");
    }
}
