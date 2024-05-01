using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Axe : WeaponManager
{
    [SerializeField] private float _axeAttackSpeed = 90f;

    public IEnumerator Swing(float duration = 2.2f)
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float time = 0.0f;
        weapon.GetComponent<BoxCollider2D>().enabled = true;
        while (time < _axeAttackSpeed)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _axeAttackSpeed * Time.deltaTime);
            yield return null;
        }
        weapon.GetComponent<BoxCollider2D>().enabled = false;
    }
}
    

