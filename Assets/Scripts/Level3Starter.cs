using UnityEngine;

public class Level3Starter : MonoBehaviour
{
    private WeaponSwitcher weaponSwitcher;

    void Start()
    {
        // Находим WeaponSwitcher
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();

        // Включаем оружие
        if (weaponSwitcher != null)
        {
            weaponSwitcher.enabled = true;
            Debug.Log("WeaponSwitcher ENABLED on Level 3");
        }
        else
        {
            Debug.LogError("WeaponSwitcher not found on Level 3!");
        }

        // Блокируем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;

        // Включаем нужные UI
        EnableUI();
    }

    void EnableUI()
    {
        // Находим StatsCanvas и ReticleCanvas и включаем их
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.name == "StatsCanvas" || canvas.name == "ReticleCanvas")
            {
                canvas.gameObject.SetActive(true);
                Debug.Log($"Enabled: {canvas.name}");
            }
        }
    }
}