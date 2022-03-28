using System;
using System.Collections.Generic;
using UnityEngine;
using static ItemManager;

public class LootManager : MonoBehaviour
{
    [SerializeField]
    private GameObject world_item_pre;
    ///<summary>
    ///Generate chest loot
    ///</summary>
    ///<param name="pos">The position where the loot should spawn</param>
    public void GenChestLoot(Transform pos)
    {
        ///The amount of each type items that will drop, in order of(EQUIPMENT, CONSUMABLE, COINS, MISC)
        int[] distribution = new int[] { 2, 3, 6, 3 };
        for (int i = 0; i < distribution.Length; i++)
        {
            for (int j = 0; j < distribution[i]; j++)
            {
                spawnLoot(i, pos);
            }
        }
    }
    public void GenKeyChestLoot(Transform pos)
    {
        GameObject worldItem = Instantiate(world_item_pre, pos);
        Item key_item = ItemManager.GetItemByName("Door key");
        worldItem.name = "i_" + key_item.Name;
        worldItem.GetComponent<SpriteRenderer>().sprite = key_item.Sprite;
        worldItem.transform.SetParent(GameObject.Find("ItemContainer").transform);
        worldItem.AddComponent<AnimateLootDrop>();
    }
    private void spawnLoot(int enumIndex, Transform pos)
    {
        ItemType it = (ItemType)enumIndex;

        GameObject worldItem = Instantiate(world_item_pre, pos);

        List<Item> itemsFromType = ItemManager.GetItemsByType((ItemType)enumIndex);
        int rngItemIndex = UnityEngine.Random.Range(0, itemsFromType.Count);

        Item sItem = itemsFromType[rngItemIndex];
        if (sItem.IsUnique) sItem = itemsFromType.Find(i => i.IsUnique == false);

        worldItem.name = "i_" + sItem.Name;
        worldItem.GetComponent<SpriteRenderer>().sprite = sItem.Sprite;
        worldItem.transform.SetParent(GameObject.Find("ItemContainer").transform);
        worldItem.AddComponent<AnimateLootDrop>();
    }
}
