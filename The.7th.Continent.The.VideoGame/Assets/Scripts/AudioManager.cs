using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the audio playback in different scenes.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// The name of the scene where the music should stop.
    /// </summary>
    public string sceneName;
    /// <summary>
    /// This variable stores the singleton instance of the AudioManager. It ensures that only one instance of the AudioManager exists 
    /// throughout the game.
    /// </summary>
    private static AudioManager instance;
    /// <summary>
    /// This variable references the AudioSource component attached to the AudioManager game object. It is used to play and stop the music.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// This function is called when a scene is loaded.
    /// </summary>
    /// <param name="scene">The loaded scene.</param>
    /// <param name="mode">The mode used to load the scene.</param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneName || scene.name == "MiniGamePingPong" || scene.name == "MiniGameCards")
        {
           
            StopMusic();
        }
        
    }

    /// <summary>
    /// Starts playing the music if it's not already playing.
    /// </summary>
    void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Stops the music playback.
    /// </summary>
    void StopMusic()
    {
        audioSource.Stop();
    }


}
