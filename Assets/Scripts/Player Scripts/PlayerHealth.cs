using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            GetComponent<DeathHandler>().HandleDeath();
        }
        healthText.text = "HP: " + health.ToString();
    }
}
