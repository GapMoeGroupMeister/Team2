using DG.Tweening;
using UnityEngine;

public class Spear : Weapon
{
    [SerializeField] private float _spearRange = 4.2f;
    [SerializeField] private float _spearAttackSpeed = 0.8f;
    private Transform _visualTrm;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnAttack()
    {
        if (!attackable) return;
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
            {
                _inputManager.AttackDirectionEvent -= HandleAttackDirection;
            })
            .Append(_visualTrm.DOLocalMoveY(1f, 0.1f))
            .AppendInterval(0.05f)
            .Append(_visualTrm.DOLocalMoveY(0, 0.1f))
            .AppendCallback(base.EndAttack)
            .AppendCallback(() =>
            {
                _inputManager.AttackDirectionEvent += HandleAttackDirection;
            });
        base.OnAttack();
        Debug.Log("공격");
    }
}
