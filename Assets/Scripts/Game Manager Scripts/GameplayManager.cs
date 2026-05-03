using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] Canvas completedCanvas;
    [SerializeField] private int enemiesLeft;

    private WeaponSwitcher weaponSwitcher; // Cache reference
    private bool levelCompleted = false; // Prevent multiple completions

    private void Awake()
    {
        completedCanvas.gameObject.SetActive(false);
        // Cache the WeaponSwitcher reference
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
    }

    private void Update()
    {
        // Only count enemies if level isn't already completed
        if (!levelCompleted)
        {
            CountEnemies();
        }
    }

    private void CountEnemies()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft < 1 && !levelCompleted)
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        levelCompleted = true; // Prevent multiple calls
        completedCanvas.gameObject.SetActive(true);

        // Use cached reference with null check
        if (weaponSwitcher != null)
            weaponSwitcher.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        SceneLoader.isPaused = true;
    }
}