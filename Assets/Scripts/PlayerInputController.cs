using Assets.Scripts.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private KeyCode _flagInputCode;
        [SerializeField] private LayerMask _baseLayer;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _navMeshSampleDistance = 1.0f;

        private BaseController _selectedBase;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleLeftClick();
            }
        }

        private void HandleLeftClick()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit baseHit, float.MaxValue, _baseLayer))
            {

                if (baseHit.collider.TryGetComponent(out BaseController clickedBase))
                {
                    _selectedBase = clickedBase;
                    return;
                }
            }

            if (_selectedBase != null)
            {

                if (Physics.Raycast(ray, out RaycastHit groundHit, float.MaxValue, _groundLayer))
                {
                    if (NavMesh.SamplePosition(groundHit.point, out NavMeshHit navHit, _navMeshSampleDistance, NavMesh.AllAreas))
                    {
                        _selectedBase.SetFlagPosition(navHit.position);

                        _selectedBase = null;
                    }
                }
            }
        }
    }
}
