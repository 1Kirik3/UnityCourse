using UnityEngine;

namespace Assets.Scripts
{
    public class CanvasBillboard : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;

            transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.forward,
                                 _mainCamera.transform.rotation * Vector3.up);
        }
    }
}
