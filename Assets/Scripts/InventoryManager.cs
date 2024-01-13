using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();
    public List<Item> Items2 = new List<Item>();

    public Transform ItemWeapon;
    public Transform ItemObject;
    public GameObject InventoryItem;

    public InventoryItemController[] inventoryItems;
    public InventoryItemController[] inventoryItems2;
    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Add2(Item item)
    {
        Items2.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        
        foreach (Transform item in ItemWeapon)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in ItemObject)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
                GameObject obj = Instantiate(InventoryItem, ItemWeapon);
                var itemName = obj.transform.Find("Name").GetComponent<Text>();
                var MaxCartridges = obj.transform.Find("Patrons").GetComponent<Text>();
                var icon = obj.transform.Find("IMG").GetComponent<Image>();

                itemName.text = item.ItemName;
                MaxCartridges.text = $"{item.x}/{item.y}";
                icon.sprite = item.icon;
            
        }
        foreach (var item in Items2)
        {
                GameObject obj = Instantiate(InventoryItem, ItemObject);
                var itemName = obj.transform.Find("Name").GetComponent<Text>();
                var MaxCartridges = obj.transform.Find("Patrons").GetComponent<Text>();
                var icon = obj.transform.Find("IMG").GetComponent<Image>();

                itemName.text = item.ItemName;
                MaxCartridges.text = $"{item.x}/{item.y}";
                icon.sprite = item.icon;
        }
        QuickInventory.Instance.SwitchImage();
        SetInventoryItems();
        
    }

    public void SetInventoryItems()
    {
        if (Items.Count != 0)
        {
            inventoryItems = ItemWeapon.GetComponentsInChildren<InventoryItemController>();
            for (int i = 0; i < Items.Count; i++)
            {
                inventoryItems[i].AddItem(Items[i]);
            }
        }
        if (Items2.Count != 0)
        { 
            inventoryItems2 = ItemObject.GetComponentsInChildren<InventoryItemController>();
            for (int i = 0; i < Items2.Count; i++)
            {
                inventoryItems2[i].AddItem(Items2[i]);
            }
        }
    }

    public void Close()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            Destroy(inventoryItems[i]);
        }
        for (int i = 0; i < Items2.Count; i++)
        {
            Destroy(inventoryItems2[i]);
        }
    }

}
