using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private float _swordAttackSpeed = 60f;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnAttack()
    {
        base.OnAttack();
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
