using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blunt : WeaponManager
{
    [SerializeField] private float _bluntRange = 3.2f;
    [SerializeField] private float _bluntAttackSpeed = 2.1f;
    protected void BluntAttack()
    {
        StartCoroutine(HitDown());
    }
    public IEnumerator HitDown(float duration = 0.8f)
    {
        float time = 0.0f;
        weapon.GetComponent<BoxCollider2D>().enabled = true;
        while (time < _bluntAttackSpeed)
        {
            time += Time.deltaTime / duration;
            transform.position += moveDir * _bluntRange;
            yield return null;
        }
        while (time > 0)
        {
            time -= Time.deltaTime / duration;
            transform.position -= moveDir * _bluntRange;
            yield return null;
        }
        weapon.GetComponent<BoxCollider2D>().enabled = false;
    }
}
