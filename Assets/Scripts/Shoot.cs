using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform Gun;
    Vector2 direction;
    public GameObject Bullet;
    public int n;
    public int i = 0;

    public float BulletSpeed;
    public Transform ShootPoint;


    public void shoot(int x, int y)
    {
        //shoot_sound.Play();
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.up * BulletSpeed);
        QuickInventory.Instance.itemNow.x = x;
        QuickInventory.Instance.itemNow.y = y;
        PlayerControl.Instance.CatridgeText.GetComponent<Text>().text = $"{x}/{y}";
    }

    public IEnumerator replace(int x, int y, int HowTorewards)
    {
        yield return new WaitForSeconds(2f);
        if (y >= HowTorewards)
        {
            y = y - HowTorewards;
            x = HowTorewards;
        }
        else if(y > 0 && y < HowTorewards)
        {
            x = y;
            y = 0;
        }
        QuickInventory.Instance.itemNow.x = x;
        QuickInventory.Instance.itemNow.y = y;
        PlayerControl.Instance.CatridgeText.GetComponent<Text>().text = $"{x}/{y}";
        For_Button.Instance.GetForShoot(x, y, QuickInventory.Instance.itemNow.fireRateItem);
    }

}
