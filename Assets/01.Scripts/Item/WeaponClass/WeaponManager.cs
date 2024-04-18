using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] protected GameObject[] weaponPrefabs;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected static int nowWeapon = 0;
    public static PlayerMovement playerMovement = new PlayerMovement();
    public static bool isAttacking = false;
    protected Vector3 moveDir = playerMovement.MoveDir;

    private int weaponCount = 5;

    private void Awake()
    {
        SetWeapon();
    }

    private void Update()
    {
        JudgeWeapon();
        ChangeWeapon();
    }

    private void SetWeapon()
    {
        Vector3 spawnPosition = transform.position;
        foreach (GameObject weaponPrefabs in weaponPrefabs)
        {
            GameObject weapon = Instantiate(weaponPrefabs, transform);
            weapon.SetActive(false);
        }
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
            Debug.Log("다음 무기 불러와야디");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            nowWeapon -= 1;
            Debug.Log("이전 무기 불러와야디");
        }
        
        nowWeapon = Mathf.Clamp(nowWeapon, 1, weaponCount);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject getTag = collision.gameObject;
        if (getTag.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        else if (getTag.CompareTag("Axe"))
        {
            nowWeapon = 1;
            Destroy(getTag);
        }
        else if (getTag.CompareTag("Shield"))
        {
            nowWeapon = 2;
            Destroy(getTag);
        }
        else if (getTag.CompareTag("Sword"))
        {
            nowWeapon = 3;
            Destroy(getTag);
        }
        else if (getTag.CompareTag("Spare"))
        {
            nowWeapon = 4;
            Destroy(getTag);
        }
        else if (getTag.CompareTag("Bow"))
        {
            nowWeapon = 5;
            Destroy(getTag);
        }
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
