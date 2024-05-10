using DG.Tweening;
using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private PlayerArrowMovement playerArrow;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnAttack()
    {
        if (!_attackable) return;
        PlayerArrowMovement arrow = Instantiate(playerArrow, transform.position, Quaternion.identity);
        arrow.transform.up = AttackDirection;
        arrow.Init(transform.position);
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
            {
                _inputManager.AttackDirectionEvent -= HandleAttackDirection;
            })
            .AppendInterval(0.1f)
            .AppendCallback(base.EndAttack)
            .AppendCallback(() =>
            {
                _inputManager.AttackDirectionEvent += HandleAttackDirection;
            });
        base.OnAttack();
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
