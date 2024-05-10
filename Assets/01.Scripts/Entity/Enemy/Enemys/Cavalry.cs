public class Cavalry : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        _attackEvent += HandleAttackEvent;

    }

    private void HandleAttackEvent()
    {
        
    }
}
