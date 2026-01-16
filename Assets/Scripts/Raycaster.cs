using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> OnCubeHitted;

    private void OnEnable()
    {
        _inputReader.MouseButtonClicked += CastRay;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonClicked -= CastRay;
    }

    private void CastRay()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                OnCubeHitted?.Invoke(cube);
            }
        }
    }
}
