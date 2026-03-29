using Assets.Scripts.Core;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class BombSpawnerStatView : SpawnerStatViewBase
    {
        [SerializeField] private BombSpawner _spawner;

        protected override IStatProvider GetSpawner() => _spawner;
    }
}
