using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the movement of a paddle in the game.
/// </summary>
public class Paddle: MonoBehaviour
{
    /// <summary>
    /// The speed at which the paddle moves
    /// </summary>
    [SerializeField] private float speed = 7f;
    /// <summary>
    /// Flag indicating if this is paddle 1 or not
    /// </summary>
    [SerializeField] private bool isPaddle1;
    /// <summary>
    /// The boundary limit for the paddle's vertical movement
    /// </summary>
    private float yBound = 3.75f;

    /// <summary>
    /// Updates the paddle's position based on player input.
    /// </summary>
    void Update()
    {
        float movement;
        if(isPaddle1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}
