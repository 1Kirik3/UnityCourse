public class DamageButtonView : ActionButtonView
{
    protected override void HandleClick()
    {
        _health.TakeDamage(_amount);
    }
}