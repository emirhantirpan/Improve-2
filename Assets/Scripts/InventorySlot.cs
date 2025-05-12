using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image iconImage;

    public void SetItem(Item item)
    {
        iconImage.sprite = item.icon;
        iconImage.enabled = true;
    }

    public void ClearSlot()
    {
        iconImage.sprite = null;
        iconImage.enabled = false;
    }
}
