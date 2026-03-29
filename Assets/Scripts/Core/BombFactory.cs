using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class BombFactory : MonoBehaviour
    {
        private readonly Bomb _prefab;
        private readonly ExploderConfig _exploderConfig;

        public BombFactory(Bomb prefab, ExploderConfig exploderConfig)
        {
            _prefab = prefab;
            _exploderConfig = exploderConfig;
        }

        public Bomb Create()
        {
            Bomb bomb = Instantiate(_prefab);
            Renderer renderer = bomb.GetComponent<Renderer>();
            Exploder exploder = new Exploder(_exploderConfig, bomb, renderer);
            bomb.Initialize(exploder);
            return bomb;
        }
    }
}
