using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blunt : Weapon
{
    [SerializeField] private float _bluntRange = 3.2f;
    [SerializeField] private float _bluntAttackSpeed = 2.1f;
    protected void SprearAttack()
    {
        StartCoroutine(HitDown());
    }
    public IEnumerator HitDown(float duration = 0.8f)
    {
        float time = 0.0f;
        GetComponent<BoxCollider>().enabled = true;
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
        GetComponent<BoxCollider>().enabled = false;
    }
}
