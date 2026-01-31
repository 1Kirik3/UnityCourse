using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Spawners
{
    public class CoinSpawner : Spawner<Coin.Coin>
    {
        protected override void Spawn(Transform point)
        {
            base.Spawn(point);
        }

    }
}

