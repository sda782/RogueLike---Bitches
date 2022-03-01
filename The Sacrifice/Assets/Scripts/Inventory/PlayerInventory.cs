using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> bag;
    private Dictionary<string, Item> equiped;
    [SerializeField]
    private GameObject panel_bag;
    [SerializeField]
    private GameObject panel_equiped;
    [SerializeField]
    private GameObject img_pre;

    void Awake()
    {
        bag = new List<Item>();
        equiped = new Dictionary<string, Item>();
        panel_bag.SetActive(false);
        panel_equiped.SetActive(false);
        bag = ItemManager.GetAllItems();
    }
    void Start()
    {
        bag.Add(ItemManager.GetItemById(0));
        bag.Add(ItemManager.GetItemById(0));
        bag.Add(ItemManager.GetItemById(0));
        bag.Add(ItemManager.GetItemById(0));
        bag.Add(ItemManager.GetItemById(1));
        bag.Add(ItemManager.GetItemById(1));
        bag.Add(ItemManager.GetItemById(2));
        bag.Add(ItemManager.GetItemById(2));
        bag.Add(ItemManager.GetItemById(2));
        bag.Add(ItemManager.GetItemById(2));
    }
    public void ToggleInventory()
    {
        panel_bag.SetActive(!panel_bag.activeSelf);
        panel_equiped.SetActive(!panel_equiped.activeSelf);
        if (panel_bag.activeSelf) UpdateInventoryView();
    }
    public void UpdateInventoryView()
    {
        GameObject container = panel_bag.transform.GetChild(1).gameObject;
        if (container.transform.childCount > 0)
        {
            foreach (var item in container.transform.GetComponentsInChildren<GameObject>())
            {
                Destroy(item);
            }
        }
        foreach (var item in bag)
        {
            GameObject itemimg = Instantiate(img_pre, container.transform);
            itemimg.GetComponent<Image>().sprite = item.Sprite;
        }
    }
}
