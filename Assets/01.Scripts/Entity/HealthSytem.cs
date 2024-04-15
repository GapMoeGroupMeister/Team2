using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSytem : MonoBehaviour
{
    [SerializeField] UnityEvent OnHpChangedEvent;
    [SerializeField] private float _hp;

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
            }
            else if (_hp < value)
            {
                //힐이 들어왔을 때 이벤트
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
}
