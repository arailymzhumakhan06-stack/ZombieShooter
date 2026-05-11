using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas statsCanvas;
    [SerializeField] Canvas reticleCanvas;

    private WeaponSwitcher weaponSwitcher;
    private bool isPaused = false;

    private void Awake()
    {
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
        StartGame();
    }

    private void StartGame()
    {
        // ¬ключаем нужные UI
        if (statsCanvas != null) statsCanvas.gameObject.SetActive(true);
        if (reticleCanvas != null) reticleCanvas.gameObject.SetActive(true);
        if (pauseCanvas != null) pauseCanvas.gameObject.SetActive(false);

        // ¬ключаем оружие
        if (weaponSwitcher != null)
            weaponSwitcher.enabled = true;

        // Ѕлокируем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        if (pauseCanvas != null) pauseCanvas.gameObject.SetActive(true);
        if (weaponSwitcher != null) weaponSwitcher.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        if (pauseCanvas != null) pauseCanvas.gameObject.SetActive(false);
        if (weaponSwitcher != null) weaponSwitcher.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Time.timeScale = 1;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}