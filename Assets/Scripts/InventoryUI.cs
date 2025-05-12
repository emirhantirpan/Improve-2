using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform slotParent;
    private InventorySlot[] slots;

    private void Start()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
        Inventory.InstanceUpdated += UpdateUI;
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
            if (!isActive) UpdateUI();
        }
    }

    public void UpdateUI()
    {
        var items = Inventory.Instance.items;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].SetItem(items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}
