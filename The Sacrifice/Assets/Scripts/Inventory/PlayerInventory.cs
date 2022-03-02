using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private List<GameObject> bag;
    private Dictionary<string, Item> equiped;
    [SerializeField]
    private GameObject bag_container;
    [SerializeField]
    private GameObject img_pre;
    [SerializeField]
    private GameObject panel_inventory;

    void Awake()
    {
        bag = new List<GameObject>();
        equiped = new Dictionary<string, Item>();
        panel_inventory.SetActive(false);
    }
    void Start()
    {
        addToInventory(0);
        addToInventory(1);
        addToInventory(0);
        addToInventory(2);
        addToInventory(0);
        addToInventory(1);
        addToInventory(1);
        addToInventory(1);
    }
    private void addToInventory(int id)
    {
        GameObject item = Instantiate(img_pre, bag_container.transform);
        Item i = ItemManager.GetItemById(id);
        item.name = i.Id.ToString();
        item.GetComponent<Image>().sprite = i.Sprite;
        bag.Add(item);
    }
    public void ToggleInventory()
    {
        panel_inventory.SetActive(!panel_inventory.activeSelf);
    }
    public static void ShowInfo(GameObject obj)
    {
        Item i = ItemManager.GetItemById(int.Parse(obj.name));
        GameObject.Find("InfoText").GetComponent<Text>().text = i.Name;
        GameObject.Find("InfoSprite").GetComponent<Image>().sprite = i.Sprite;
    }
}
