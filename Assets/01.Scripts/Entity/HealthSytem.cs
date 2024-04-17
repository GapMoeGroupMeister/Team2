using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSytem : MonoBehaviour
{
    
    [SerializeField] UnityEvent OnHpChangedEvent;
    [SerializeField] protected SpriteRenderer entity;

    [SerializeField] protected float _hp;

    private void Start()
    {
        entity = entity.GetComponent<SpriteRenderer>();
    }

    public float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            if (_hp != value)
            {
                OnHpChangedEvent?.Invoke();
            }
            if (_hp > value)
            {
                //HP�� ���� �� �̺�Ʈ
                StartCoroutine("Damaged");
            }
            else if (_hp < value)
            {
                //���� ������ �� �̺�Ʈ 
                StartCoroutine("Healed");
            }
            _hp = value;
        }
    }

    public void ResetHP(float maxHp)
    {
        HP = maxHp;
    }

    public void SetHP(float value)
    {
        HP = value;
    }

    // ������ ������ �����Ÿ�
    IEnumerator Damaged() 
    {
        entity.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        entity.color = Color.white;
    }

    IEnumerator Healed()
    {
        entity.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        entity.color = Color.white;
    }
}
