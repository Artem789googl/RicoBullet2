using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Item.TypeCatridges TypeCart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") | collision.CompareTag("Body") && QuickInventory.Instance.itemNow != null)
        {
            if (QuickInventory.Instance.itemNow.ValueCartridges == TypeCart)
            {

                if (QuickInventory.Instance.itemNow.y < QuickInventory.Instance.itemNow.MaxCartridges)
                {
                    int a = Random.Range(3, QuickInventory.Instance.itemNow.MaxCartridges - QuickInventory.Instance.itemNow.y);
                    For_Button.Instance.GetForShoot(QuickInventory.Instance.itemNow.x, QuickInventory.Instance.itemNow.y + a, QuickInventory.Instance.itemNow.fireRateItem);
                    Destroy(gameObject);
                }
                
            }

            foreach (var item in InventoryManager.Instance.Items)
            {
                if (item.ValueCartridges == TypeCart)
                {
                    if (item.y < item.MaxCartridges)
                    {
                        int a = Random.Range(3, item.MaxCartridges - item.y);
                        item.y = item.y + a;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
