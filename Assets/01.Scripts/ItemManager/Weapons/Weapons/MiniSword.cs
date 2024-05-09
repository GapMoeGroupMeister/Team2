using DG.Tweening;
using UnityEngine;

public class MiniSword : Weapon
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("dfdf");
    }

    protected override void OnAttack()
    {
        base.OnAttack();
        Debug.Log("dfdf");
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
    

