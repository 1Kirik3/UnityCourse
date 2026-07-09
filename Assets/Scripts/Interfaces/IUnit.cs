using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IUnit
    {
        bool IsFree { get; }
        void AssignTask(IResource resource, IBase homeBase);

    }
}


