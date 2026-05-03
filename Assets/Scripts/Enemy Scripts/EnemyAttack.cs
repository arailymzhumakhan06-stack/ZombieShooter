using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 30f;

    private void Awake()
    {
        target = FindFirstObjectByType<PlayerHealth>();
    }

    void AttackHitEvent()
    {
        if (target == null)
            return;
        target.TakeDamage(damage);
    }
}