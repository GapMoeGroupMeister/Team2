using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private PlayerArrow playerArrow;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnAttack()
    {
        base.OnAttack();
        Instantiate(playerArrow, transform.position, Quaternion.LookRotation(AttackDirection));
        playerArrow.Init(this);
        playerArrow.OnAttack(AttackDirection);
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
