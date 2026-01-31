using UnityEngine;

namespace Assets.Scripts.Spawners
{
    public class AidSpawner : Spawner<FirstAidKid.FirstAidKid>
    {
        [SerializeField, Range(0f, 1f)] private float _spawnChance = 0.3f;

        protected override void Spawn(Transform point)
        {
            if (Random.value <= _spawnChance)
            {
                base.Spawn(point);
            }
        }
    }
}
