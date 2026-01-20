using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> OnCubeHitted;

    private void OnEnable()
    {
        _inputReader.ActionPerformed += CastRay;
    }

    private void OnDisable()
    {
        _inputReader.ActionPerformed -= CastRay;
    }

    private void CastRay(Vector2 screenPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                OnCubeHitted?.Invoke(cube);
            }
        }
    }
}