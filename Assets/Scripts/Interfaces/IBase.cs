using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IBase
    {
        Vector3 Position { get; }
        void ReceiveResource();

    }
}


