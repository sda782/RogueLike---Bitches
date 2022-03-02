using UnityEngine;

public class Item
{
    public Item(int id, string name, int rarity, Sprite sprite, bool equipable)
    {
        Id = id;
        Name = name;
        Rarity = rarity;
        Sprite = sprite;
        Equipable = equipable;
        Sprite = Resources.Load<Sprite>("Sprites/Items/i_" + id);
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Rarity { get; set; }
    public Sprite Sprite { get; set; }
    public bool Equipable { get; set; }
}
