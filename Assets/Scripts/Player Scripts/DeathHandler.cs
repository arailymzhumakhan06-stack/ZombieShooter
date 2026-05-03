using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    private WeaponSwitcher weaponSwitcher; // Cache reference

    private void Awake()
    {
        gameOverCanvas.gameObject.SetActive(false);
        // Cache the WeaponSwitcher reference
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
    }

    public void HandleDeath()
    {
        SceneLoader.isPaused = true;
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;

        // Use cached reference with null check
        if (weaponSwitcher != null)
            weaponSwitcher.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}