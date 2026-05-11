using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] DamageFlash damageFlash; // Добавьте эту строку

    private Level3Survival survival; // Добавлено для Level 3

    private void Start()
    {
        // Находим Level3Survival (если он есть на сцене)
        survival = FindFirstObjectByType<Level3Survival>();
    }


    public void TakeDamage(float damage)
    {
        

        // Визуальный фидбек
        if (damageFlash != null)
            damageFlash.Flash();

        health -= damage;

        AudioManager.Instance?.PlayDamage();
        if (health <= 0)
        {
            health = 0;

            // Если мы на Level 3 - уведомляем о поражении
            if (survival != null)
                survival.LoseGame();

            GetComponent<DeathHandler>().HandleDeath();
        }

        if (healthText != null)
            healthText.text = "HP: " + health.ToString();
    }
}