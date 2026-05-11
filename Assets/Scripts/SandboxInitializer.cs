using UnityEngine;
using System.Collections;

public class SandboxInitializer : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("SandboxInitializer Awake - INITIALIZING SANDBOX");

        // Принудительно сбрасываем время
        Time.timeScale = 1;

        // Сбрасываем курсор для FPS
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Находим и ВКЛЮЧАЕМ WeaponSwitcher
        WeaponSwitcher weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
        if (weaponSwitcher != null)
        {
            weaponSwitcher.enabled = true;
            Debug.Log("WeaponSwitcher ENABLED in Sandbox");
        }
        else
        {
            Debug.LogWarning("WeaponSwitcher not found in Sandbox!");
        }

        // Включаем все武器
        Weapon[] weapons = FindObjectsByType<Weapon>(FindObjectsSortMode.None);
        Debug.Log($"Found {weapons.Length} weapons in Sandbox");
        foreach (Weapon w in weapons)
        {
            w.enabled = true;
            Debug.Log($"Weapon {w.name} ENABLED");
        }

        // Включаем нужные UI
        EnableUI();

        // Сбрасываем состояние паузы
        SceneLoader.isPaused = false;
    }

    void EnableUI()
    {
        // Используем FindFirstObjectByType вместо FindObjectOfType
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
            if (canvas.name == "MenuCanvas")
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    void Start()
    {
        StartCoroutine(DelayedForce());
    }

    IEnumerator DelayedForce()
    {
        yield return new WaitForSeconds(0.1f);

        WeaponSwitcher ws = FindFirstObjectByType<WeaponSwitcher>();
        if (ws != null)
        {
            ws.enabled = false;
            yield return null;
            ws.enabled = true;
            Debug.Log("WeaponSwitcher FORCE TOGGLED in Sandbox");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Sandbox: Mouse click detected!");
        }
    }
}