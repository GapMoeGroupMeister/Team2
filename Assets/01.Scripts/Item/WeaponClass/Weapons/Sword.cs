using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponManager
{

    [SerializeField] private float _swordAttackSpeed = 1.2f;
    private float save = 0;

    public IEnumerator SwordWield(float duration = 0.8f)
    {
        float time = 0.0f;
        weapon.GetComponent<BoxCollider>().enabled = true;
        while (time < _swordAttackSpeed)
        {
            time += Time.deltaTime / duration;
            transform.position += moveDir * _swordAttackSpeed;
            save += _swordAttackSpeed;
            yield return null;
        }
        transform.position -= moveDir * save;
        weapon.GetComponent<BoxCollider>().enabled = false;
    }
}
