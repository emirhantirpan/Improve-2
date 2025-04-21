using UnityEngine;

public abstract class Item
{
    public string itemName;
    public Sprite icon;

    public Item(string name, Sprite icon)
    {
        this.itemName = name;
        this.icon = icon;
    }

    public abstract void Use(); // �rnek davran�� (kullan�ld���nda ne olur?)
}
