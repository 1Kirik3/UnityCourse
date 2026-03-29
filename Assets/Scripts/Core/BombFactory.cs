using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class BombFactory : MonoBehaviour
    {
        [SerializeField] private ExploderConfig _exploderConfig;

        public void Setup(Bomb bomb)
        {
            Exploder exploder = new Exploder(_exploderConfig, bomb, bomb.Renderer);
            bomb.Initialize(exploder);
        }
    }
}
