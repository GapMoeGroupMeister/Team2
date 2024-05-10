public class Shield : Weapon
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnAttack()
    {
        if (attackable==false) return;
        base.OnAttack();
    }

    protected override void EndAttack()
    {
        base.EndAttack();
    }
}
