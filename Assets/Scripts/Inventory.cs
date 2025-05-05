using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public delegate void OnInventoryUpdated();
    public static event OnInventoryUpdated InstanceUpdated;

    

    public List<Item> items = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        if (newItem != null)
        {
            items.Add(newItem);
            Debug.Log(newItem.itemName + " envantere eklendi!");
            InstanceUpdated?.Invoke();
        }
    }
}
