using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private PlayerArrow playerArrow;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnAttack()
    {
        base.OnAttack();
        PlayerArrow arrow = Instantiate(playerArrow, transform.position, Quaternion.identity);
        arrow.transform.up = AttackDirection;
        arrow.Init(this);
        arrow.OnAttack(AttackDirection);
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
