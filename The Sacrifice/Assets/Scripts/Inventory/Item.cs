using System;
using UnityEngine;
using static ItemManager;

[System.Serializable]
public class Item
{
    public int Id;
    public string Name;
    public int Rarity;
    public Sprite Sprite;
    public bool Equipable;
    public string ItemType;
    public bool IsUnique;

    public void SetSprite()
    {
        Sprite = Resources.Load<Sprite>("Sprites/Items/i_" + Name);
    }
}
