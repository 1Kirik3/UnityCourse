using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.ResourcesLogic
{
    public class ResourceDatabase : MonoBehaviour, IResourceDatabase
    {
        private readonly HashSet<IResource> _unreservedResources = new HashSet<IResource>();
        private readonly HashSet<IResource> _reservedResources = new HashSet<IResource>();

        public event Action ResourceAdded;

        public void RegisterFoundResource(IResource resource)
        {
            if (_unreservedResources.Contains(resource) || _reservedResources.Contains(resource))
            {
                return;
            }

            _unreservedResources.Add(resource);
            resource.Collected += HandleResourceCollected;

            // Будим все базы на карте!
            ResourceAdded?.Invoke();
        }

        public bool TryGetUnreservedResource(out IResource resource)
        {
            foreach (var candidate in _unreservedResources)
            {
                resource = candidate;
                _unreservedResources.Remove(resource);
                _reservedResources.Add(resource);
                return true;
            }

            resource = null;
            return false;
        }

        public void UnreserveResource(IResource resource)
        {
            if (_reservedResources.Remove(resource))
            {
                _unreservedResources.Add(resource);
                ResourceAdded?.Invoke();
            }
        }

        private void HandleResourceCollected(IResource resource)
        {
            resource.Collected -= HandleResourceCollected;
            _unreservedResources.Remove(resource);
            _reservedResources.Remove(resource);
        }
    }
}
