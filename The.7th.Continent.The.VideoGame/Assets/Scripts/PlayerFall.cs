using UnityEngine;

/// <summary>
/// Class that represents when a character falls
/// </summary>
public class PlayerFall : MonoBehaviour
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
    /// Function that resets the character to its starting position if the trigger is touched when it falls
    /// </summary>
    /// <param name="other">Variable representing a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = playerStartPosition;    
        }
    }

}
