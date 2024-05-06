using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class HealthSytem : MonoBehaviour
{

    [SerializeField] UnityEvent OnHpChangedEvent;
    
    [SerializeField] protected ParticleSystem ps;

    [SerializeField] protected float _hp;

    private void Start()
    {
        ps = gameObject.GetComponentsInChildren<ParticleSystem>()[0];
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
                ps.Play();
            }
            else if (_hp < value)
            {
                //���� ������ �� �̺�Ʈ 
                
            }
            _hp = value;
        }
    }






}
