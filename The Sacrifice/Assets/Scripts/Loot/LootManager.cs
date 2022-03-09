using System;
using System.Collections.Generic;
using UnityEngine;
using static ItemManager;

public class LootManager : MonoBehaviour
{
    [SerializeField]
    private GameObject world_item_pre;
    public void GenChestLoot(Transform pos)
    {
        // EQUIPMENT, COMSUMABLE, COINS, MISC
        int[] distribution = new int[] { 1, 2, 5, 2 };
        for (int i = 0; i < distribution.Length - 1; i++)
        {
            for (int j = 0; j < distribution[i]; j++)
            {
                // Spawn Loot Item
                spawnLoot(i, pos);
            }
        }
    }
    private void spawnLoot(int enumIndex, Transform pos)
    {
        ItemType it = (ItemType)enumIndex;
        GameObject worldItem = Instantiate(world_item_pre, pos);
        List<Item> itemsFromType = ItemManager.GetItemsByType((ItemType)enumIndex);
        worldItem.name = "i_" + itemsFromType[0].Name;
        worldItem.GetComponent<SpriteRenderer>().sprite = itemsFromType[0].Sprite;
        worldItem.transform.SetParent(GameObject.Find("ItemContainer").transform);
    }
}
