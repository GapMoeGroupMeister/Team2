using DG.Tweening;
using UnityEngine;

public class Spear : Weapon
{
    [SerializeField] private float _spearRange = 4.2f;
    [SerializeField] private float _spearAttackSpeed = 0.8f;
    private Transform _visualTrm;

    protected override void Awake()
    {
        base.Awake();
        _visualTrm = transform.Find("Visual");
    }

    protected override void OnAttack()
    {
        base.OnAttack();
        Sequence seq = DOTween.Sequence();
        seq.Append(_visualTrm.DOLocalMoveY(1f, 0.15f))
            .Append(_visualTrm.DOLocalMoveY(0f, 0.23f))
            .AppendCallback(EndAttack);
    }

    protected override void EndAttack()
    {
        base.EndAttack(); 
    }
}
