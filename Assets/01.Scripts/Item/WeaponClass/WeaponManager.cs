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
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected int nowWeapon = 0;
    public static PlayerMovement playerMovement = new PlayerMovement();
    public static bool isAttacking = false;
    protected Vector3 moveDir = playerMovement.MoveDir;

    private int weaponCount = 5;

    

    private void Update()
    {
        JudgeWeapon();
        ChangeWeapon();
    }

    private void JudgeWeapon()
    {
        if (Input.GetMouseButton(0) && isAttacking == false)
        {
            switch (nowWeapon)
            {
                case 1:
                    isAttacking = true;
                    break;
                case 2:
                    isAttacking = true;
                    break;

                case 3:
                    isAttacking = true;
                    break;
                case 4:
                    isAttacking = true;
                    break;
                case 5:
                    isAttacking = true;
                    break;
            }
        }
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            nowWeapon += 1;

            if (nowWeapon > weaponCount) nowWeapon -= weaponCount;
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
    }
}
