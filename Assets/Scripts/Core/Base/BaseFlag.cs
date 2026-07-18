using UnityEngine;

namespace Assets.Scripts.Core.Base
{
    public class BaseFlag : MonoBehaviour
    {
        private bool _isPlaced;

        public bool IsPlaced => _isPlaced;
        public Vector3 Position => transform.position;

        private void Awake()
        {
            Hide();
        }

        public void PlaceAt(Vector3 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
            _isPlaced = true;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _isPlaced = false;
        }
    }
}
