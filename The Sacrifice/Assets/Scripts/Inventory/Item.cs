using System;
using UnityEngine;
[System.Serializable]
public class Item
{
    public int Id;
    public string Name;
    public int Rarity;
    public Sprite Sprite;
    public bool Equipable;
    public void SetSprite()
    {
        Sprite = Resources.Load<Sprite>("Sprites/Items/i_" + Name);
    }
}
