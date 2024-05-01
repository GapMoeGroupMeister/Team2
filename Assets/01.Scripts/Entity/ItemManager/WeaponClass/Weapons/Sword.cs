using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponManager
{
    [SerializeField] private float _swordAttackSpeed = 60f;

    public IEnumerator SwordAttack(float duration = 1.2f)
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float time = 0.0f;
        weapon.GetComponent<BoxCollider2D>().enabled = true;
        while (time < _swordAttackSpeed)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _swordAttackSpeed * Time.deltaTime);
            yield return null;
        }
        weapon.GetComponent<BoxCollider2D>().enabled = false;
    }

}
