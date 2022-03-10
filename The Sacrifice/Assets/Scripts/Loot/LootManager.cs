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
    ///<param name="distribution">The amount of each type items that will drop, in order of(EQUIPMENT, CONSUMABLE, COINS, MISC)</param>
    public void GenChestLoot(Transform pos, int[] distribution)
    {
        if (distribution.Length != 4) throw new ArgumentOutOfRangeException("distribution must contain 4 elements");
        for (int i = 0; i < distribution.Length; i++)
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
        int rngItemIndex = UnityEngine.Random.Range(0, itemsFromType.Count);
        worldItem.name = "i_" + itemsFromType[rngItemIndex].Name;
        worldItem.GetComponent<SpriteRenderer>().sprite = itemsFromType[rngItemIndex].Sprite;
        worldItem.transform.SetParent(GameObject.Find("ItemContainer").transform);
        worldItem.AddComponent<AnimateLootDrop>();
    }
}
