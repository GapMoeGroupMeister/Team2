using Crogen.HealthSystem;
using UnityEngine;


public class EnemyHpUI : MonoBehaviour
{
    
    public DefaultHealthSystem healthSystem;

    public void Init(DefaultHealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        this.healthSystem.hpChangeEvent.AddListener(HandlerHpChangeEvent);
    }

    private void HandlerHpChangeEvent()
    {
        //transform.localScale = new Vector3(healthSystem.HP/healthSystem.maxHp, 1, 1);
    }
}
