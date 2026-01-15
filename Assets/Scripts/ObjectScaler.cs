using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private float _scalingFactor;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        _transform.localScale += Vector3.one * _scalingFactor;
    }
}
