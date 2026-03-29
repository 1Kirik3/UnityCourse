using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class BombSpawner : BaseSpawner<Bomb>
    {
        [Header("Bomb Factory Config")]
        [SerializeField] private ExploderConfig _exploderConfig;

        private BombFactory _factory;

        protected override void Awake()
        {
            _factory = new BombFactory(_prefab, _exploderConfig);
            base.Awake();
        }

        protected override Bomb CreateObject()
        {
            TotalCreated++;
            RaiseStatsChanged();
            return _factory.Create();
        }
    }
}
