using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Sprite icon;
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwordItem newItem = new SwordItem(itemName, icon);
            Inventory.Instance.AddItem(newItem);
            Destroy(gameObject); // Toplanan obje sahneden kaldýrýlýr
        }
    }
}
