using UnityEngine;

public class SwordItem : Item
{
    public SwordItem(string name, Sprite icon) : base(name, icon) { }

    public override void Use()
    {
        Debug.Log(itemName + " kullanýldý (örnek).");
    }
}
