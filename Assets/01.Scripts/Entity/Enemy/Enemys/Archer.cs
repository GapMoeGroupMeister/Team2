using UnityEngine;

public class Archer : Enemy
{
    [SerializeField] private ArrowMovement _arrowPrefab;
    
    protected override void Awake()
    {
        base.Awake();
        _attackEvent += HandleAttackEvent;

    }

    private void HandleAttackEvent()
    {
        ArrowMovement arrow = Instantiate(_arrowPrefab, transform.position, Quaternion.identity);
        arrow.archer = this;
        arrow.Init();
    }
}
