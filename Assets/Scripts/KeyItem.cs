using UnityEngine;

public class KeyItem : Item
{
    public KeyItem(string name, Sprite icon) : base(name, icon) { }

    public override void Use()
    {
        Debug.Log(itemName + " kullan�ld�. Kap� a��l�yor...");
    }
}
