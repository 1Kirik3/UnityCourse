using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const float MinRandomValue = 0f;
    private const float MaxRandomValue = 1f;

    public event Action<Cube> Clicked;

    [field: SerializeField] public Renderer Renderer { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    public int SpawnGeneration { get; private set; } = 1;
    public float SplitChance { get; private set; } = 1f;

    public void Initialize(int spawnGeneration, float splitChance, float scale)
    {
        SpawnGeneration = spawnGeneration;
        SplitChance = splitChance;
        transform.localScale = Vector3.one * scale;
    }

    public bool CanSplit()
    {
        return UnityEngine.Random.Range(MinRandomValue, MaxRandomValue) <= SplitChance;
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);
    }
}