using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] protected GameObject sword;
    [SerializeField] protected GameObject spear;
    [SerializeField] protected GameObject axe;
    [SerializeField] protected GameObject blunt;
    [SerializeField] protected GameObject bow;
    [SerializeField] protected GameObject player;
    [SerializeField] protected int nowWeapon = 0;
    public static PlayerMovement playerMovement = new PlayerMovement();
    public static bool isAttacking = false;
    public static bool isAxe = false;
    public static bool isShield = false;
    public static bool isSword = false;
    public static bool isSpear = false;
    public static bool isBow = false;
    protected Vector3 moveDir = playerMovement.MoveDir;

    

    private void Update()
    {
       

        if (Input.GetMouseButton(0) && isAttacking == false)
        {
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
                isSpear = true;
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

    protected void SwordAttack()
    {
        
    }

    public void AttackEnd()
    {
        Destroy(gameObject);
    }

    public int NowWeapon
    {
        get { return nowWeapon; }
        set { nowWeapon = value; }
    }

}
