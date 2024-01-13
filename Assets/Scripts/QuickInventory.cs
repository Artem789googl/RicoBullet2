using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickInventory : MonoBehaviour
{
    public static QuickInventory Instance;

    public List<GameObject> BD = new List<GameObject>(1);


    public Sprite Active;
    public Sprite NotActive;

    public GameObject Switch_B;
    public GameObject InventoryItem;

    public Item itemNow;
    private void Awake()
    {
        Instance = this;
    }

    public void GetItem(Item item)
    {
        itemNow = item;
    }

    public void AddQuick()
    {
        if (itemNow.WT == Item.WeaponType.Easy)
        {
            

            GameObject obj = Instantiate(InventoryItem, BD[0].transform);
            obj.transform.SetParent(gameObject.transform);
            obj.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            obj.GetComponent<InventoryItemController>().item = itemNow;

            var itemName = obj.transform.Find("Name").GetComponent<Text>();
            var MaxCartridges = obj.transform.Find("Patrons").GetComponent<Text>();
            var icon = obj.transform.Find("IMG").GetComponent<Image>();

            itemName.text = itemNow.ItemName;
            MaxCartridges.text = $"{itemNow.x}/{itemNow.y}";
            icon.sprite = itemNow.icon;
            Destroy(BD[0]);
            BD.RemoveAt(0);
            BD.Insert(0, obj);
        }
        else if(itemNow.WT == Item.WeaponType.Hard)
        {

            GameObject obj = Instantiate(InventoryItem, BD[1].transform);
            obj.transform.SetParent(gameObject.transform);
            obj.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            obj.GetComponent<InventoryItemController>().item = itemNow;

            var itemName = obj.transform.Find("Name").GetComponent<Text>();
            var MaxCartridges = obj.transform.Find("Patrons").GetComponent<Text>();
            var icon = obj.transform.Find("IMG").GetComponent<Image>();

            itemName.text = itemNow.ItemName;
            MaxCartridges.text = $"{itemNow.x}/{itemNow.y}";
            icon.sprite = itemNow.icon;

            Destroy(BD[1]);
            BD.RemoveAt(1);
            BD.Insert(1, obj);
        }
        SwitchImage();
        SwitchActive();
    }

    public void SwitchImage()
    {
        foreach (Transform item in InventoryManager.Instance.ItemWeapon)
        {
             if (BD[0].GetComponentInChildren<Text>() && BD[0].GetComponentInChildren<Text>().text == item.gameObject.GetComponentInChildren<Text>().text)
             {
                 item.gameObject.GetComponent<Image>().sprite = Active;
             }else if(BD[1].GetComponentInChildren<Text>() && BD[1].GetComponentInChildren<Text>().text == item.gameObject.GetComponentInChildren<Text>().text)
             {
                 item.gameObject.GetComponent<Image>().sprite = Active;
             }
             else
             {
                 item.gameObject.GetComponent<Image>().sprite = NotActive;
             }
        }
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        foreach (Transform item in InventoryManager.Instance.ItemWeapon)
        {
            if (BD[0].GetComponentInChildren<Text>())
            {
                var MaxCartridges = BD[0].transform.Find("Patrons").GetComponent<Text>();

                MaxCartridges.text = $"{BD[0].GetComponent<InventoryItemController>().item.x}/{BD[0].GetComponent<InventoryItemController>().item.y}";
            }
            else if (BD[1].GetComponentInChildren<Text>())
            {
                var MaxCartridges = BD[1].transform.Find("Patrons").GetComponent<Text>();

                MaxCartridges.text = $"{BD[1].GetComponent<InventoryItemController>().item.x}/{BD[1].GetComponent<InventoryItemController>().item.y}";
            }
        }
    }

    public void SwitchActive()
    {
        if (BD[0].name != "BD_1" && BD[1].name != "BD_2")
        {
            Switch_B.SetActive(true);
        }
    }

}
