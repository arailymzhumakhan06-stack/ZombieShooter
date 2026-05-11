using UnityEngine;

public class SandboxPause : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas; // Перетащите PauseCanvas сюда
    private bool isPaused = false;

    void Start()
    {
        // Убеждаемся, что пауза выключена при старте
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        // Блокируем курсор для FPS
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;

        Debug.Log("SandboxPause initialized - press ESC to pause");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed - toggling pause");

            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Pause activated");
        isPaused = true;
        Time.timeScale = 0;

        if (pauseCanvas != null)
            pauseCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        Debug.Log("Resume activated");
        isPaused = false;
        Time.timeScale = 1;

        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sandbox");
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