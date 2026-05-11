using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    bool isDead = false;
    public bool IsDead { get => isDead; }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        health -= damage;

        // Звук получения урона (опционально, если хотите)
        AudioManager.Instance?.PlayZombieHit();

        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        if (isDead)
            return;

        isDead = true;

        // Воспроизводим звук смерти
        AudioManager.Instance?.PlayZombieDeath();

        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<EnemyAI>().enabled = false;
        StartCoroutine(DestroyEnemyObject());
    }

    private IEnumerator DestroyEnemyObject()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}