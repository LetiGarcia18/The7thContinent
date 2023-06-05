using UnityEngine;

/// <summary>
/// Class that represents when the character collides with a trap
/// </summary>
public class TrapScript : MonoBehaviour
{
    /// <summary>
    /// Represents the character
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Represents the character position
    /// </summary>
    private Vector2 playerStartPosition;

    /// <summary>
    /// Class that assigns the position of the character to the internal position variable
    /// </summary>
    void Start()
    {
        playerStartPosition = player.transform.position;
    }

    /// <summary>
    /// Function that resets the character to its starting position if he touches a trap
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = playerStartPosition;
        }
    }
}
