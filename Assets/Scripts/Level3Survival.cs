using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level3Survival : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] float survivalTime = 120f;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    [Header("Zombie Spawn")]
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] int maxZombies = 10;

    private float timeRemaining;
    private bool isGameOver = false;
    private int currentZombies = 0;

    void Start()
    {
        timeRemaining = survivalTime;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        StartCoroutine(SpawnZombies());
    }

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;
        UpdateTimerUI();

        if (timeRemaining <= 0)
            WinGame();
    }

    void UpdateTimerUI()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (timeRemaining < 30f)
            timerText.color = Color.red;
        else if (timeRemaining < 60f)
            timerText.color = Color.yellow;
    }

    System.Collections.IEnumerator SpawnZombies()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (isGameOver) yield break;
            if (currentZombies >= maxZombies) continue;

            if (timeRemaining < 30f)
                spawnInterval = 1f;
            else if (timeRemaining < 60f)
                spawnInterval = 1.5f;

            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        if (spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        currentZombies++;
        StartCoroutine(TrackZombie(zombie));
    }

    System.Collections.IEnumerator TrackZombie(GameObject zombie)
    {
        yield return new WaitUntil(() => zombie == null);
        currentZombies--;
    }

    void WinGame()
    {
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoseGame()
    {
        if (isGameOver) return;
        isGameOver = true;
        losePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level3");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }
}