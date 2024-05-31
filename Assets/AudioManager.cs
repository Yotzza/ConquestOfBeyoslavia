using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source-------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("-------Audio Clip-------")]
    public AudioClip background;
    public AudioClip hit;
    public AudioClip specialSceneMusic;

    private static AudioManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // dodaj listener za promene scena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music Source or Background Clip is not set in the Inspector.");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Ucitana scena: " + scene.path);
        if (scene.path == "Assets/Scenes/Stages/SampleScene.unity" || scene.path == "Assets/Scenes/Stages/stage2.unity" || scene.path == "Assets/Scenes/Stages/stage3.unity" || scene.path == "Assets/Scenes/Stages/stage4.unity" || scene.path == "Assets/Scenes/Stages/stage5.unity" || scene.path == "Assets/Scenes/Stages/stage6.unity" || scene.path == "Assets/Scenes/Stages/stage7.unity" || scene.path == "Assets/Scenes/Stages/stage8.unity" || scene.path == "Assets/Scenes/Stages/stage9.unity")
        {
            if (musicSource.clip != specialSceneMusic)
            {
                musicSource.clip = specialSceneMusic;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != background)
            {
                musicSource.clip = background;
                musicSource.Play();
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // SFX
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
