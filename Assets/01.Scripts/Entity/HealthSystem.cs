using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class HealthSystem : MonoBehaviour
{
    public UnityEvent OnHpChangedEvent;
    
    [SerializeField] protected ParticleSystem ps;

    [SerializeField] protected float _hp;
    [HideInInspector] public float maxHp;
    
    private void Start()
    {
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
        maxHp = _hp;
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
