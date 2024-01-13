using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    private bool trig;

    public void Pickup()
    {
        if(For_Button.isClick)
        {
            if (Item.Type == Item.ItemType.Weapon)
            {
                InventoryManager.Instance.Add(Item);
                if(Item.weapt == Item.WeapT.Weapon)
                {
                    int x = Take.other2.gameObject.GetComponent<ItemCartridges>().x;
                    int y = Take.other2.gameObject.GetComponent<ItemCartridges>().y;

                    Item.x = x;
                    Item.y = y;
                }
            }
            else if(Item.Type == Item.ItemType.Object)
            {
                InventoryManager.Instance.Add2(Item);
            }
            Destroy(gameObject);
        }
        For_Button.isClick = false;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Body"))
        {
            trig = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Body"))
        {
            trig = false;
        }
        For_Button.isClick = false;
    }
    void FixedUpdate()
    {
        if (trig & For_Button.isClick)
        {
            Pickup();           
        }
    }
}
