using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IResource
    {
        Vector3 Position { get; }
        bool IsTargeted { get; }
        void SetTargeted(bool state);
        void PickUp(Transform carryPoint);
        void Collect();

    }
}


