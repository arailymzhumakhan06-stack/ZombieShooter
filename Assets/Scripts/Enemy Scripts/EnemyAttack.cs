using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 30f;

    // Добавьте ссылку на DamageFlash
    private DamageFlash damageFlash;

    private void Awake()
    {
        target = FindFirstObjectByType<PlayerHealth>();

        // Найти DamageFlash на сцене
        if (target != null)
        {
            damageFlash = FindFirstObjectByType<DamageFlash>();
        }
    }

    void AttackHitEvent()
    {
        if (target == null)
            return;

        // Визуальный фидбек МГНОВЕННО
        if (damageFlash != null)
        {
            damageFlash.Flash();
            Debug.Log("Flash from EnemyAttack at: " + Time.time);
        }

        target.TakeDamage(damage);
    }
}