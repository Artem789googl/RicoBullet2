using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Trigger : MonoBehaviour
{

    public Door door;

    public bool Close = false;

    [Header("Dialogie")]
    public DialogueTrigger Dialogue;
    public string NeedKey;

    


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Body" || collision.tag == "Enemy")
        {
            foreach (Item item in InventoryManager.Instance.Items2)
            {
                if (NeedKey == item.ItemName)
                {
                    Close = false;
                }
            }
            if (Close)
            {
                Dialogue.TriggerDialogue();
            }
            else
            {
                door.Open();
            }
            
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Body" || collision.tag == "Enemy")
        {
            door.Close();
        }
    }


}
