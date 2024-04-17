using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] public int nowWeapon = 0;
    public static bool isAttacking = false;
    public static bool isAxe = false;
    public static bool isShield = false;
    public static bool isSword = false;
    public static bool isSpare = false;
    public static bool isBow = false;

    private void Update()
    {
       

        if (Input.GetMouseButton(0) && isAttacking == false)
        {
            //°ø°Ý ¾Ö´Ï¸ÞÀÌ¼Ç ¿¬µ¿
            if (nowWeapon == 1)
            {
                isAttacking = true;
                isAxe = true;
            }

            if (nowWeapon == 2)
            {
                isAttacking = true;
                isShield = true;
            }

            if (nowWeapon == 3)
            {
                isAttacking = true;
                isSword = true;
            }

            if (nowWeapon == 4)
            {
                isAttacking = true;
                isSpare = true;
            }

            if (nowWeapon == 5)
            {
                isAttacking = true;
                isBow = true;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Axe"))
        {
            nowWeapon = 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            nowWeapon = 2;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Sword"))
        {
            nowWeapon = 3;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Spare"))
        {
            nowWeapon = 4;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bow"))
        {
            nowWeapon = 5;
            Destroy(collision.gameObject);
        }
    }

    public void AttackEnd()
    {
        Destroy(gameObject);
    }

    public override void Attack()
    {
        if (nowWeapon == 1)
        {
            Invoke("AttackEnd", 1f);
            isAxe = false;
            isAttacking = false;
            AttackEnd();
        }
    }

}
