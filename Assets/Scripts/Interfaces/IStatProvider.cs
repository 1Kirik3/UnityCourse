
namespace Assets.Scripts.Interfaces
{
    public interface IStatProvider
    {
        int TotalSpawned { get; }
        int TotalCreated { get; }
        int ActiveCount { get; }

        event System.Action OnStatsChanged;

    }
}
