using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class For_Button : MonoBehaviour
{

    public static For_Button Instance;

    public Animator GetText;
    public GameObject Shoot_B2;
    public GameObject Panel_Menu;

    private Shoot shoot;


    public static bool isClick = false;

    int x, y;

    bool a = true;

    public float fireRate;

    private float nextFireTime = 0f;
    private bool isShooting = false;

    public Animator PanelQuest;

    void Update()
    {
        if (isShooting)
        {
            if (Time.time > nextFireTime)
            {

                Shoot_B();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public void OnShootButtonDown()
    {
        // Вызываем при удержании кнопки
        isShooting = true;
    }

    public void OnShootButtonUp()
    {

        // Вызываем при отпускании кнопки
        isShooting = false;
    }
    private void Awake()
    {
        Instance = this;
    }


    public void Pause() {
        Time.timeScale = 0f;
        Panel_Menu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Panel_Menu.SetActive(false);
    }

    public void Exit(int scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void PlayAnimTrigger(string Trigger)
    {
        PanelQuest.SetTrigger(Trigger);
    }

    public void TakeB()
    {
        isClick = true;
        if (Take.other2.tag == "People" & Take.other2.GetComponent<DialogueTrigger>() && isClick == true)
        {
            Take.other2.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        if (Take.other2.tag == "Weapon" || Take.other2.tag == "Object" && isClick == true)
        {
            GetText.gameObject.GetComponent<Text>().text = $"Get: {Take.other2.name}";
            GetText.SetTrigger("Play");
        }
    }


    public void GetForShoot(int xg, int yg, float restforfier)
    {
        x = xg;
        y = yg;
        fireRate = restforfier;
        PlayerControl.Instance.CatridgeText.GetComponent<Text>().text = $"{x}/{y}";
    }

    public void Shoot_B()
    {
        shoot = GameObject.FindGameObjectWithTag("Body").GetComponent<Shoot>();
        if(QuickInventory.Instance.itemNow.weapt == Item.WeapT.Weapon)
        {
            if (x > 0)
            {
                x--;
                shoot.shoot(x, y);
            }
            else {
                shoot.StartCoroutine(shoot.replace(x, y, QuickInventory.Instance.itemNow.HowToReplace));
            }
        }
        
        
    }

    public void SwitchB()
    {
        if (a == true)
        {
            PlayerControl.Instance.Change(QuickInventory.Instance.BD[0].GetComponent<InventoryItemController>().item.BodyWGun);
            QuickInventory.Instance.GetItem(QuickInventory.Instance.BD[0].GetComponent<InventoryItemController>().item);
            a = false;
        }
        else
        {
            PlayerControl.Instance.Change(QuickInventory.Instance.BD[1].GetComponent<InventoryItemController>().item.BodyWGun);
            QuickInventory.Instance.GetItem(QuickInventory.Instance.BD[1].GetComponent<InventoryItemController>().item);
            a = true;
        }
        GetForShoot(QuickInventory.Instance.itemNow.x, QuickInventory.Instance.itemNow.y, QuickInventory.Instance.itemNow.fireRateItem);
    }
  
}
