using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const float MinRandomNumberChance = 0f;
    private const float MaxRandomNumberChance = 1f;
    private const float ScaleFactor = 2f;

    [field: SerializeField] public Renderer Renderer {  get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }

    [SerializeField] private float _baseExplosionForce = 50f;
    [SerializeField] private float _baseExplosionRadius = 2f;

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
        float scaleMultiplier = 1f / Mathf.Pow(ScaleFactor, _spawnGeneration - 1);
        transform.localScale = _startScale * scaleMultiplier;
    }

    public bool TrySplit(out int spawnGeneration, out float splitChance)
    {
        spawnGeneration = _spawnGeneration;
        splitChance = _splitChance;
        bool isSplitted = Random.Range(MinRandomNumberChance, MaxRandomNumberChance) <= _splitChance;

        return isSplitted;
    }

    public void Explode()
    {
        float currentForce = _baseExplosionForce * _spawnGeneration;
        float currentRadius = _baseExplosionRadius * _spawnGeneration;

        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, currentRadius);

        foreach (Collider hit in overlappedColliders)
        {
            Cube cube = hit.GetComponent<Cube>();

            if (cube != null)
            {
                cube.Rigidbody.AddExplosionForce(currentForce, transform.position, currentRadius);
            }
        }

        Destroy(gameObject);
    }

}
