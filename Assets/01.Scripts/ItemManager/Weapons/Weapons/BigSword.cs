using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BigSword : Weapon
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnAttack()
    {
        base.OnAttack();
        Sequence seq = DOTween.Sequence();
        seq.Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 80f), 0.3f))
            .AppendInterval(0.1f)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, -45f), 0.3f))
            .AppendInterval(0.1f)
            .AppendCallback(EndAttack)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 80f), 0.4f));
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
