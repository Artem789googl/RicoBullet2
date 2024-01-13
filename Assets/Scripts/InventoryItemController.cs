using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{

    public Item item;

    

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.Type)
        {
            case Item.ItemType.Weapon:
                Table_INV.Instance.Dobav(item.ItemName, item.Damage, item.Diraction);
                QuickInventory.Instance.GetItem(item);
                For_Button.Instance.GetForShoot(item.x, item.y, item.fireRateItem);
                PlayerControl.Instance.Change(item.BodyWGun);
                PlayerControl.Instance.onShoot();
                break;
            case Item.ItemType.Object:
                Table_INV.Instance.Dobav(item.ItemName, item.Damage, item.Diraction);
                break;
        }
    }
}
