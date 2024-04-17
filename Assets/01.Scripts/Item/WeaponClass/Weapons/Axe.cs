using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Axe : MonoBehaviour
{
    public GameObject axePrefab;

    private GameObject _WeaponObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
        }
    }

    private void Update()
    {
       /* if (WeaponManager.nowWeapon.)
        {
            GameObject Axe = Instantiate(axePrefab);
            isAttacking();
            Cooltime(3);
        }*/
    }
}
    

