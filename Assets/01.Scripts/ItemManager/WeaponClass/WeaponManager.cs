using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    [SerializeField] protected GameObject[] weaponPrefabs;
    [SerializeField] protected GameObject[] weaponObjs = new GameObject[5];
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected int nowWeapon = 1;
    [SerializeField] protected float _arrowSpeed = 100f;
    private float _desiredAngle;
    protected BoxCollider2D weaponCollider;
    public bool isAttacking = false;
    protected Vector3 moveDir;

    private readonly int weaponCount = 5;

    protected void Awake()
    {
        moveDir = PlayerManager.Instance.MoveDir;
        
        SetWeapon();
    }

    private void Start()
    {
    }

    private void Update()
    {
        JudgeWeapon();
        ChangeWeapon();
    }

    private void SetWeapon()
    {
        for (int i = 0; i < weaponPrefabs.Length; ++i)
        {
            weaponObjs[i] = Instantiate(weaponPrefabs[i], transform);
            weaponObjs[i].SetActive(false);
        }
    }

    private void JudgeWeapon()
    {
        if (Input.GetMouseButton(0) && isAttacking == false)
        {
            isAttacking = true;
            weapon = weaponObjs[nowWeapon-1];
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

    private void WeaponDir()
    {
        Vector3 aimDir = moveDir;
        _desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.AngleAxis(_desiredAngle, Vector3.forward);
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
