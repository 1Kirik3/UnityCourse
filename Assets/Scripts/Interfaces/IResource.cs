using System;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IResource
    {
        Vector3 Position { get; }
        event Action<IResource> Collected;
        void PickUp(Transform carryPoint);
        void Collect();
    }
}


