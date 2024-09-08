using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;
    public BulletGun Bg;
    public enum BulletGun {Enemy, Player};

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            PlayerControl.Instance.PlayerHealthInt -= damage;

            //Vignette a = PlayerControl.Instance.VolumeHealth.GetComponent<Vignette>();
            //a.intensity = 
            Destroy(gameObject);
            if (PlayerControl.Instance.PlayerHealthInt <= 0)
            {
                PlayerControl.Instance.PlayerHealthInt = 100;
                PlayerControl.Instance.gameObject.transform.position = PlayerControl.Instance.TargetToRespawn.position;
            }
        }else if (collision.CompareTag("Enemy"))
        {
            EnemyHealth.HealthEnemy -= damage;
        }
    }

    private void Update()
    {
        if (BulletGun.Player == Bg)
        {
            damage = QuickInventory.Instance.itemNow.Damage;
        }
        
    }
}
