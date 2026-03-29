
namespace Assets.Scripts.Interfaces
{
    public interface IStatProvider
    {
        event System.Action OnStatsChanged;

        int TotalSpawned { get; }
        int TotalCreated { get; }
        int ActiveCount { get; }

    }
}
