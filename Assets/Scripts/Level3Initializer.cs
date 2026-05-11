using UnityEngine;
using System.Collections;

public class Level3Initializer : MonoBehaviour
{
    private WeaponSwitcher weaponSwitcher;

    void Awake()
    {
        // ✅ ПРОВЕРКА: если это не Level 3 - уничтожаем объект
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Level3")
        {
            Debug.Log($"Level3Initializer: Not in Level 3 (current: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}), destroying self");
            Destroy(gameObject);
            return;
        }

        Debug.Log("Level3Initializer Awake - FORCING FIX");

        // Принудительно сбрасываем всё
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Находим и включаем оружие
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
        if (weaponSwitcher != null)
        {
            weaponSwitcher.enabled = true;
            Debug.Log("WeaponSwitcher ENABLED by Level3Initializer");
        }

        // Также включаем все Weapon скрипты
        Weapon[] weapons = FindObjectsByType<Weapon>(FindObjectsSortMode.None);
        foreach (Weapon w in weapons)
        {
            w.enabled = true;
            Debug.Log($"Weapon {w.name} ENABLED");
        }

        // Включаем UI
        EnableUI();
    }

    void EnableUI()
    {
        Canvas[] allCanvases = FindObjectsByType<Canvas>(FindObjectsSortMode.None);

        foreach (Canvas canvas in allCanvases)
        {
            if (canvas.name == "StatsCanvas" || canvas.name == "ReticleCanvas")
            {
                canvas.gameObject.SetActive(true);
                Debug.Log($"UI {canvas.name} ENABLED");
            }
            if (canvas.name == "PauseCanvas")
            {
                canvas.gameObject.SetActive(false);
                Debug.Log($"UI {canvas.name} DISABLED");
            }
        }
    }

    void Start()
    {
        StartCoroutine(DelayedFix());
    }

    IEnumerator DelayedFix()
    {
        yield return new WaitForSeconds(0.1f);

        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
        if (weaponSwitcher != null)
        {
            weaponSwitcher.enabled = false;
            yield return null;
            weaponSwitcher.enabled = true;
            Debug.Log("WeaponSwitcher TOGGLED for safety");
        }
    }

    void Update()
    {
        // Отладка кликов мыши
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse click detected in Level3 - SHOULD WORK!");
        }
    }
}