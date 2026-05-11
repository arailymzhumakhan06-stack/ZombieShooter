using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource footstepSource;

    [Header("Music")]
    [SerializeField] AudioClip backgroundMusic;

    [Header("SFX - Weapons")]
    [SerializeField] AudioClip shootSound;

    [Header("SFX - Zombie")]
    [SerializeField] AudioClip zombieHitSound;
    [SerializeField] AudioClip zombieDeathSound;

    [Header("SFX - Player")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip[] footstepSounds; // Массив звуков шагов

    [Header("SFX - Pickup")]
    [SerializeField] AudioClip pickupSound;

    private void Awake()
    {
        // Singleton pattern - чтобы AudioManager был один на всю игру
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Запускаем фоновую музыку
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Методы для воспроизведения звуков
    public void PlayShoot()
    {
        if (shootSound != null)
            sfxSource.PlayOneShot(shootSound);
    }

    public void PlayZombieHit()
    {
        if (zombieHitSound != null)
            sfxSource.PlayOneShot(zombieHitSound);
    }

    public void PlayZombieDeath()
    {
        if (zombieDeathSound != null)
            sfxSource.PlayOneShot(zombieDeathSound);
    }

    public void PlayDamage()
    {
        if (damageSound != null)
            sfxSource.PlayOneShot(damageSound);
    }

    public void PlayPickup()
    {
        if (pickupSound != null)
            sfxSource.PlayOneShot(pickupSound);
    }

    public void PlayFootstep()
    {
        if (footstepSounds.Length > 0 && footstepSource != null)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            footstepSource.PlayOneShot(footstepSounds[randomIndex]);
        }
    }

    public bool IsFootstepPlaying()
    {
        return footstepSource.isPlaying;
    }

    // Регулировка громкости
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
            sfxSource.volume = volume;
    }
}