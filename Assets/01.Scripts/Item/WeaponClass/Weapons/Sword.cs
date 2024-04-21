using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponManager
{
    [SerializeField] private GameObject player;
    [SerializeField] private float _swordAttackSpeed = 60f;
    private float save = 0;

    protected void SwordAttack()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _swordAttackSpeed * Time.deltaTime);
    }

}
