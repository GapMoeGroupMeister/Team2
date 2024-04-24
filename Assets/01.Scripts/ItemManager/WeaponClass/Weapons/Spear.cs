using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponManager
{
    [SerializeField] private float _spearRange = 4.2f;
    [SerializeField] private float _spearAttackSpeed = 0.8f;
    protected void SprearAttack()
    {
        StartCoroutine(Sting());
    }
    public IEnumerator Sting(float duration = 0.8f)
    {
        float time = 0.0f;
        weapon.GetComponent<BoxCollider>().enabled = true;
        while (time < _spearAttackSpeed)
        {
            time += Time.deltaTime / duration;
            transform.position += moveDir *  _spearRange;
            yield return null;
        }
        while (time > 0)
        {
            time -= Time.deltaTime / (duration * 2);
            transform.position -= moveDir * _spearRange;
            yield return null;
        }
        weapon.GetComponent<BoxCollider>().enabled = false;
    }
}
