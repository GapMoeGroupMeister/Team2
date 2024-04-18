using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] protected GameObject swordPrefab;
    [SerializeField] protected GameObject spearPrefab;
    [SerializeField] protected GameObject axePrefab;
    [SerializeField] protected GameObject bluntPrefab;
    [SerializeField] protected GameObject bowPrefab;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected int nowWeapon = 0;
    public static PlayerMovement playerMovement = new PlayerMovement();
    public static bool isAttacking = false;
    protected Vector3 moveDir = playerMovement.MoveDir;

    private int weaponCount = 5;

    private void Awake()
    {
        Vector3 spawnPosition = transform.position;
        GameObject spawnedSword = Instantiate(swordPrefab, spawnPosition, Quaternion.identity);
        GameObject spawnedSpear = Instantiate(spearPrefab, spawnPosition, Quaternion.identity);
        GameObject spawnedAxe = Instantiate(axePrefab, spawnPosition, Quaternion.identity);
        GameObject spawnedBlunt = Instantiate(bluntPrefab, spawnPosition, Quaternion.identity);
        GameObject spawnedBow = Instantiate(bowPrefab, spawnPosition, Quaternion.identity);
        swordPrefab.transform.parent = transform;
        spearPrefab.transform.parent = transform;
        axePrefab.transform.parent = transform;
        bluntPrefab.transform.parent = transform;
        bowPrefab.transform.parent = transform;
        swordPrefab.SetActive(false);
        spearPrefab.SetActive(false);
        axePrefab.SetActive(false);
        bluntPrefab.SetActive(false);
        bowPrefab.SetActive(false);

    }

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
