namespace Assets.Scripts.HealthPackage.Buttons
{
    public class DamageButtonView : ActionButtonView
    {
        protected override void HandleClick()
        {
            Health.TakeDamage(Amount);
        }
    }
}
