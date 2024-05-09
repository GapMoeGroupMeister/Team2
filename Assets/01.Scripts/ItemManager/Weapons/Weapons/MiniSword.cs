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
        if (isAttack) return;
        Debug.Log("공격");
        Sequence seq = DOTween.Sequence();
        base.OnAttack();
        seq.Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 80f), 0.1f))
            .AppendInterval(0.1f)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, -45f), 0.1f))
            .AppendInterval(0.1f)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 80f), 0.1f))
            .AppendCallback(base.EndAttack);
    }
}