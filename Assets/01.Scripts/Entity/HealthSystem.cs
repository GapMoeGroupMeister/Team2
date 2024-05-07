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
                //HP가 깎였을 때 이벤트
                ps.Play();
            }
            else if (_hp < value)
            {
                //힐이 들어왔을 때 이벤트 
                
            }
            _hp = value;
        }
    }






}
