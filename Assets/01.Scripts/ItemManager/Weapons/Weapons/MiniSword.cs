using DG.Tweening;
using UnityEngine;

public class MiniSword : Weapon
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnAttack()
    {
        if (attackable==false) return;
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
            {
                _inputManager.AttackDirectionEvent -= HandleAttackDirection;
            })
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 80f), 0.1f))
            .AppendInterval(0.1f)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, -45f), 0.1f))
            .AppendInterval(0.1f)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 80f), 0.1f))
            .AppendCallback(base.EndAttack)
            .AppendCallback(() =>
            {
                _inputManager.AttackDirectionEvent += HandleAttackDirection;
            });
        base.OnAttack();
    }
}