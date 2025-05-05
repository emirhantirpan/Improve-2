using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;       // Inspector'dan panel atanacak
    public Transform slotParent;            // Grid Layout objesi
    private InventorySlot[] slots;

    private void Start()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
        Inventory.InstanceUpdated += UpdateUI;

        inventoryPanel.SetActive(false); // Oyun baþlarken gizli
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Envanter tuþu: 'I'
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);

            if (!isActive)
                UpdateUI();
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
