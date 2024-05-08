using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Blunt : Weapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnAttack()
    {
        base.OnAttack();
        Sequence seq = DOTween.Sequence();
        seq.Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 35f), 0.3f))
            .AppendInterval(0.1f)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, -90f), 0.3f))
            .AppendInterval(0.1f)
            .AppendCallback(EndAttack)
            .Append(_visualTrm.DOLocalRotate(new Vector3(0, 0, 0f), 0.4f));
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
