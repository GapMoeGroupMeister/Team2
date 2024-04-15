using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Axe : MonoBehaviour
{

    private GameObject _WeaponObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }




   /* private int WeaponDamage(int damage)
    {
        damage = 10;
    }

    private int WeaponCooltime(float Cooltime)
    {
        Cooltime = 3f;
    }*/
}
    

