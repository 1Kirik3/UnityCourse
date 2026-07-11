using Assets.Scripts.Core.ResourcesLogic;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class BaseScanner : MonoBehaviour
    {
        [SerializeField] private float _scanRadius = 50f;
        [SerializeField] private LayerMask _resourceLayer;
        [SerializeField] private float _scanInterval = 1f;
        [SerializeField] private ResourceDatabase _resourceDatabase;

        private void Start()
        {
            StartCoroutine(ScanRoutine());
        }

        private IEnumerator ScanRoutine()
        {
            var waitInterval = new WaitForSeconds(_scanInterval);

            while (true)
            {
                yield return waitInterval;
                ScanForResources();
            }
        }

        private void ScanForResources()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _scanRadius, _resourceLayer);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out IResource resource))
                {
                    _resourceDatabase.RegisterFoundResource(resource);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _scanRadius);
        }
    }
}
