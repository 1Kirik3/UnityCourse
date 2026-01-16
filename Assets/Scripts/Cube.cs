using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [field: SerializeField] public Renderer Renderer {  get; private set; }

    private const float _minRandomNumberChance = 0f;
    private const float _maxRandomNumberChance = 1f;
    private const float _scaleFactor = 2f;

    private Vector3 _startScale;
    private int _spawnGeneration = 1;
    private float _splitChance = 1f;

    public void Initilize(int spawnGeneration, float splitChance)
    {
        _spawnGeneration = spawnGeneration;
        _splitChance = splitChance;
        _startScale = transform.localScale;
    }

    public void ReduceScale()
    {
        float scaleMultiplier = 1f / Mathf.Pow(_scaleFactor, _spawnGeneration - 1);
        transform.localScale = _startScale * scaleMultiplier;
    }

    public bool TrySplit(out int spawnGeneration, out float splitChance)
    {
        spawnGeneration = _spawnGeneration;
        splitChance = _splitChance;
        bool isSplitted = Random.Range(_minRandomNumberChance, _maxRandomNumberChance) <= _splitChance;

        if (isSplitted)
        {
            return true;
        }

        return false;
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
