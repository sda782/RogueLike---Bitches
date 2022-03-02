using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private List<GameObject> bag;
    private Dictionary<string, Item> equiped;
    [SerializeField]
    private GameObject bag_container;
    [SerializeField]
    private GameObject item_pre;
    [SerializeField]
    private GameObject world_item_pre;
    [SerializeField]
    private GameObject panel_inventory;
    private static GameObject panel_showinfo;
    private static GameObject currentSelected = null;
    [SerializeField]
    private Transform playerPos;

    void Awake()
    {
        bag = new List<GameObject>();
        equiped = new Dictionary<string, Item>();
        panel_showinfo = GameObject.Find("ItemInfo");
        panel_showinfo.SetActive(false);
        panel_inventory.SetActive(false);
        playerPos = GameObject.Find("Player").transform;
    }
    public void addToInventory(int id)
    {
        GameObject item = Instantiate(item_pre, bag_container.transform);
        Item i = ItemManager.GetItemById(id);
        item.name = "i_" + i.Id.ToString();
        item.GetComponent<Image>().sprite = i.Sprite;
        bag.Add(item);
    }

    public void DropItem()
    {
        if (currentSelected == null) return;
        GameObject worldItem = Instantiate(world_item_pre, playerPos);
        worldItem.name = currentSelected.name;
        worldItem.GetComponent<SpriteRenderer>().sprite = ItemManager.GetItemById(int.Parse(currentSelected.name.Substring(2))).Sprite;
        worldItem.transform.SetParent(GameObject.Find("ItemContainer").transform);
        RemoveFromInventory();
    }
    public void RemoveFromInventory()
    {
        Destroy(bag.Find(g => g == currentSelected));
        panel_showinfo.SetActive(false);
    }
    public void ToggleInventory()
    {
        panel_inventory.SetActive(!panel_inventory.activeSelf);
        if (panel_inventory.activeSelf == false) panel_showinfo.SetActive(false);
    }
    public static void ShowInfo(GameObject obj)
    {
        panel_showinfo.SetActive(true);
        Item i = ItemManager.GetItemById(int.Parse(obj.name.Substring(2)));
        GameObject.Find("InfoText").GetComponent<Text>().text = i.Name;
        GameObject.Find("InfoSprite").GetComponent<Image>().sprite = i.Sprite;
        currentSelected = obj;
    }
}
