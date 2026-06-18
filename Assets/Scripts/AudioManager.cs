using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Header("SFX")]
    public AudioClip moveSound;
    public AudioClip hoverSound;
public AudioClip clickSound;

public AudioClip captureSound;
public AudioClip pocketPlaceSound;
public AudioClip checkSound;
public AudioClip checkmateSound;
public AudioClip winnerPopupSound;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
            PlayMusic(menuMusic);
        else
            PlayMusic(gameMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip)
            return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayMoveSound()
    {
        sfxSource.PlayOneShot(moveSound);
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
    }
    public void PlayHoverSound()
{
    sfxSource.PlayOneShot(hoverSound);
}

public void PlayClickSound()
{
    sfxSource.PlayOneShot(clickSound);
}

public void PlayCaptureSound()
{
    sfxSource.PlayOneShot(captureSound);
}

public void PlayPocketPlaceSound()
{
    sfxSource.PlayOneShot(pocketPlaceSound);
}

public void PlayCheckSound()
{
    sfxSource.PlayOneShot(checkSound);
}

public void PlayCheckmateSound()
{
    sfxSource.PlayOneShot(checkmateSound);
}

public void PlayWinnerPopupSound()
{
    sfxSource.PlayOneShot(winnerPopupSound);
}
}