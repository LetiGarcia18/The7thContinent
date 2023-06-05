using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls vertical movement of an object.
/// </summary>
public class VerticalMovement : MonoBehaviour
{
    /// <summary>
    /// The movement speed
    /// </summary>
    public float speed = 2.0f;
    /// <summary>
    /// The maximum distance to move
    /// </summary>
    public float distance = 2.0f;
    /// <summary>
    /// The starting position
    /// </summary>
    private Vector2 startPos;
    /// <summary>
    /// The movement direction
    /// </summary>
    private float direction = 1.0f;

    /// <summary>
    /// Called at the start of the script execution.
    /// Stores the starting position of the object.
    /// </summary>
    private void Start()
    {
        startPos = transform.position;
    }

    /// <summary>
    /// Called every frame.
    /// Moves the object vertically based on the defined speed and direction.
    /// </summary>
    private void Update()
    {
        float newX = transform.position.y + (direction * speed * Time.deltaTime);

        if (newX > startPos.y + distance)
        {
            newX = startPos.y + distance;
            direction = -1.0f;
        }
        else if (newX < startPos.y - distance)
        {
            newX = startPos.y - distance;
            direction = 1.0f;
        }

        transform.position = new Vector2(newX, transform.position.x);
        FlipSprite();
    }

    /// <summary>
    /// Flips the object's sprite based on the movement direction.
    /// </summary>
    private void FlipSprite()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.y = Mathf.Abs(currentScale.y) * (direction == 1.0f ? -1.0f : 1.0f);
        transform.localScale = currentScale;
    }
}

