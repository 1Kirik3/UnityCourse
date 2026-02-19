public class HealButtonView : ActionButtonView
{
    protected override void HandleClick()
    {
        _health.Heal(_amount);
    }
}