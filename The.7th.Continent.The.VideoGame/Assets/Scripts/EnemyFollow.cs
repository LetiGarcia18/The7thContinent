using UnityEngine;

/// <summary>
/// Class that represents the chase between the character and the enemy character
/// </summary>
public class EnemyFollow : MonoBehaviour
{
    /// <summary>
    /// Enemy character speed
    /// </summary>
    public float enemySpeed;

    /// <summary>
    /// Variable that stores the position, rotation, scale and parenting status of the character.
    /// </summary>
    public Transform player;

    /// <summary>
    /// In the Update function, the coordinates are being given to the enemy character, 
    /// so that he can follow the main character at a certain distance and at a certain speed.
    /// </summary>
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), enemySpeed * Time.deltaTime);
    }


}
