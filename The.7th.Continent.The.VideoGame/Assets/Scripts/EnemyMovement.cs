using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the movement of the enemy character.
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Movement speed
    /// </summary>
    public float speed = 2.0f;
    /// <summary>
    /// Distance to move
    /// </summary>
    public float distance = 2.0f;
    /// <summary>
    /// Starting position of the enemy
    /// </summary>
    private Vector2 startPos;
    /// <summary>
    /// Movement direction (1.0f for right, -1.0f for left)
    /// </summary>
    private float direction = 1.0f;

    /// <summary>
    /// The Start function is called when the object is first initialized.
    /// It stores the starting position of the enemy.
    /// </summary>
    private void Start()
    {
        startPos = transform.position;
    }

    /// <summary>
    /// The Update function is called every frame. It calculates the new position of the enemy based on its current position,
    /// direction, speed, and time.
    /// If the enemy exceeds the specified distance from its starting position, it changes direction.
    /// It then updates the enemy's position and flips its sprite if necessary.
    /// </summary>
    private void Update()
    {
        float newX = transform.position.x + (direction * speed * Time.deltaTime);

        if (newX > startPos.x + distance)
        {
            newX = startPos.x + distance;
            direction = -1.0f;
        }
        else if (newX < startPos.x - distance)
        {
            newX = startPos.x - distance;
            direction = 1.0f;
        }

        transform.position = new Vector2(newX, transform.position.y);
        FlipSprite();
    }

    /// <summary>
    /// Flips the sprite horizontally based on the movement direction.
    /// </summary>
    private void FlipSprite()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x = Mathf.Abs(currentScale.x) * (direction == 1.0f ? -1.0f : 1.0f);
        transform.localScale = currentScale;
    }

}
