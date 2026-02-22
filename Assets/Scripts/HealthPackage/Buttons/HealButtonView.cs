namespace Assets.Scripts.HealthPackage.Buttons
{
    public class HealButtonView : ActionButtonView
    {
        protected override void HandleClick()
        {
            Health.Heal(Amount);
        }
    }
}
