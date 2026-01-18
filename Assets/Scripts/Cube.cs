using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const float MinRandomNumberChance = 0f;
    private const float MaxRandomNumberChance = 1f;
    private const float ScaleFactor = 2f;

    [field: SerializeField] public Renderer Renderer { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

    private Vector3 _startScale;
    public int SpawnGeneration { get; private set; } = 1;
    public float SplitChance { get; private set; } = 1f;

    public void Initilize(int spawnGeneration, float splitChance)
    {
        SpawnGeneration = spawnGeneration;
        SplitChance = splitChance;
        _startScale = transform.localScale;
    }

    public void ReduceScale()
    {
        float scaleMultiplier = 1f / Mathf.Pow(ScaleFactor, SpawnGeneration - 1);
        transform.localScale = _startScale * scaleMultiplier;
    }

    public bool TrySplit()
    {
        return Random.Range(MinRandomNumberChance, MaxRandomNumberChance) <= SplitChance;
    }

}
