using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that represents when a character falls
/// </summary>
public class PlayerFallFinalEnemyScene : MonoBehaviour
{
    /// <summary>
    /// Variable representing a GameObject
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Variable representing the positions of a GameObject
    /// </summary>
    private Vector2 playerStartPosition;

    /// <summary>
    /// Function where the position of the player is assigned to the internal variable
    /// </summary>
    void Start()
    {
        playerStartPosition = player.transform.position;
    }

    /// <summary>
    /// Function that completely resets the scene when the character falls and touches the trigger
    /// </summary>
    /// <param name="other">Variable representing a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Restart();    
        }
    }

    /// <summary>
    /// Function that resets the scene and resets the gems number.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        RestartGems();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Esto nos regresa el nombre de la escena en la que estamos actualmente
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
