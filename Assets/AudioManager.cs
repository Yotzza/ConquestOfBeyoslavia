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
        if (scene.path == "Assets/Scenes/Stages/SampleScene.unity")
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
