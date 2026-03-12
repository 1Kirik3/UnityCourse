using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class VampirismArea : MonoBehaviour
{
    private readonly List<IDamageable> _targetsInArea = new List<IDamageable>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable target))
        {
            _targetsInArea.Add(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable target))
        {
            _targetsInArea.Remove(target);
        }
    }

    public IDamageable GetClosestTarget(Vector3 origin)
    {
        IDamageable closest = null;
        float minSqrDistance = Mathf.Infinity;

        _targetsInArea.RemoveAll(t => t == null || (t is MonoBehaviour mb && mb.gameObject == null));

        foreach (var target in _targetsInArea)
        {
            if (target is MonoBehaviour targetMono)
            {
                float sqrDistance = (targetMono.transform.position - origin).sqrMagnitude;

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    closest = target;
                }
            }
        }

        return closest;
    }
}
