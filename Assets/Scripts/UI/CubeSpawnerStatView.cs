using Assets.Scripts.Core;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CubeSpawnerStatView : SpawnerStatViewBase
    {
        [SerializeField] private CubeSpawner _spawner;

        protected override IStatProvider GetSpawner() => _spawner;
    }
}
