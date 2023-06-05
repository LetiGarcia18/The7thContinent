using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that represents that if the enemy character touches the player, the player starts over in the scene.
/// </summary>
public class EnemyTouchPlayer : MonoBehaviour
{
    /// <summary>
    /// Represents the character.
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Represents the start character position.
    /// </summary>
    private Vector2 playerStartPosition;

    /// <summary>
    /// The initial position of the character is stored in a variable.
    /// </summary>
    void Start()
    {
        playerStartPosition = player.transform.position;
    }

    /// <summary>
    /// It is checked if the enemy character comes into contact with the character. If so, start the scene again.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Restart();
        }
    }

    /// <summary>
    /// Function that makes the scene start again and resets the gems number.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        RestartGems();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Function that resets the gems number.
    /// </summary>
    private void RestartGems()
    {
        var gems = PlayerPrefs.GetInt("gems");
        var temporalGems = PlayerPrefs.GetInt("temporalGems");
        gems = gems - temporalGems;
        PlayerPrefs.SetInt("gems", gems);
        PlayerPrefs.SetInt("temporalGems", 0);
    }
}
