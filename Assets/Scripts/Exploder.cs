using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 50f;
    [SerializeField] private float _baseExplosionRadius = 5f;

    public void ExplodeNewCubes(List<Cube> cubes, Vector3 position)
    {
        foreach (var cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_baseExplosionForce, position, _baseExplosionRadius);
        }
    }

    public void ExplodeEverything(Vector3 position, int generation)
    {
        float currentForce = _baseExplosionForce * generation;
        float currentRadius = _baseExplosionRadius * generation;

        Collider[] overlappedColliders = Physics.OverlapSphere(position, currentRadius);

        foreach (Collider hit in overlappedColliders)
        {
            if (hit.TryGetComponent(out Cube cube))
            {
                cube.Rigidbody.AddExplosionForce(currentForce, position, currentRadius);
            }
        }
    }
}