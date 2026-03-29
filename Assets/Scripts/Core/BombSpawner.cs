using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class BombSpawner : BaseSpawner<Bomb>
    {
        [Header("Bomb Factory Config")]
        [SerializeField] private ExploderConfig _exploderConfig;
        [SerializeField] private BombFactory _factory;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override Bomb CreateObject()
        {
            Bomb bomb = Instantiate(_prefab);
            _factory.Setup(bomb);

            TotalCreated++;
            RaiseStatsChanged();

            return bomb;
        }
    }
}
