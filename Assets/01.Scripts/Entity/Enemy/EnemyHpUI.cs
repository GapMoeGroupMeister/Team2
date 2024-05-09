using UnityEngine;


public class EnemyHpUI : MonoBehaviour
{
    
    public HealthSystem healthSystem;

    public void Init(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        this.healthSystem.OnHpChangedEvent.AddListener(HandlerHpChangeEvent);
    }

    private void HandlerHpChangeEvent()
    {
        //transform.localScale = new Vector3(healthSystem.HP/healthSystem.maxHp, 1, 1);
    }
}
