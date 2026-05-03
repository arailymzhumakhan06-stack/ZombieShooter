using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas statsCanvas;
    [SerializeField] Canvas reticleCanvas;
    [SerializeField] Camera menuCamera, gameplayCamera;

    public static bool isPaused;
    private WeaponSwitcher weaponSwitcher; // Cache reference

    private void Awake()
    {
        // Cache the WeaponSwitcher reference - FIXED: FindFirstObjectByType
        weaponSwitcher = FindFirstObjectByType<WeaponSwitcher>();
        StartMenu();
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
        }
    }

    private void StartMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        menuCamera.enabled = true;
        gameplayCamera.enabled = false;
        Time.timeScale = 0;
        isPaused = true;
        pauseCanvas.gameObject.SetActive(false);
        statsCanvas.gameObject.SetActive(false);
        reticleCanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        isPaused = false;
        gameplayCamera.enabled = true;
        menuCamera.enabled = false;
        menuCanvas.gameObject.SetActive(false);
        reticleCanvas.gameObject.SetActive(true);
        statsCanvas.gameObject.SetActive(true);

        // Enable weapon switcher
        if (weaponSwitcher != null)
            weaponSwitcher.enabled = true;

        // Lock cursor for FPS gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        if (weaponSwitcher != null)
            weaponSwitcher.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1; // Reset time scale before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed - Application.Quit() called");

#if UNITY_EDITOR
        // This stops play mode in the Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
    // This quits the built game
    Application.Quit();
#endif
    }

    public void Pause()
    {
        isPaused = true;
        ToggleCanvases(isPaused);

        if (weaponSwitcher != null)
            weaponSwitcher.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        ToggleCanvases(isPaused);

        if (weaponSwitcher != null)
            weaponSwitcher.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void ToggleCanvases(bool paused)
    {
        pauseCanvas.gameObject.SetActive(paused);
        statsCanvas.gameObject.SetActive(!paused);
        reticleCanvas.gameObject.SetActive(!paused);
    }
}