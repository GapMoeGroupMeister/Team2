using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    [SerializeField] protected GameObject[] weaponPrefabs;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected int nowWeapon = 1;
    [SerializeField] protected float _arrowSpeed = 100f;
    protected BoxCollider2D weaponCollider;
    public bool isAttacking = false;
    protected Vector3 moveDir;

    private int weaponCount = 5;

    protected override void Awake()
    {
        base.Awake();
        moveDir = PlayerManager.Instance.MoveDir;
        weaponCollider = weapon.GetComponent<BoxCollider2D>();
    }

    private void Start()
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

            isAttacking = true;

            switch (nowWeapon)
            {
                case 1:
                    weapon = weaponPrefabs[0];
                    break;

                case 2:
                    weapon = weaponPrefabs[1];
                    break;

                case 3:
                    weapon = weaponPrefabs[2];
                    break;

                case 4:
                    weapon = weaponPrefabs[3];
                    break;

                case 5:
                    weapon = weaponPrefabs[4];
                    break;
            }
        }
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            nowWeapon += 1;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            nowWeapon -= 1;
        }
        
        nowWeapon = Mathf.Clamp(nowWeapon, 1, weaponCount);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject getTag = collision.gameObject;

        switch (getTag.tag)
        {
            case "Eneny":
                Destroy(gameObject);
                break;
            case "Axe":
                nowWeapon = 1;
                Destroy(getTag);
                break;
            case "Shield":
                nowWeapon = 2;
                Destroy(getTag);
                break;
            case "Sword":
                nowWeapon = 3;
                Destroy(getTag);
                break;
            case "Spare":
                nowWeapon = 4;
                Destroy(getTag);
                break;
            case "Bow":
                nowWeapon = 5;
                Destroy(getTag);
                break;

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
