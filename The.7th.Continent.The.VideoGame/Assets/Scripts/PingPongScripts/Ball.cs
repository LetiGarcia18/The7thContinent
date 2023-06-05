using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script controls the behavior of the ball in the game.
/// </summary>
public class Ball : MonoBehaviour
{
    /// <summary>
    /// The initial velocity of the ball
    /// </summary>
    [SerializeField] private float initialVelocity = 4f;
    /// <summary>
    /// The multiplier for increasing the velocity
    /// </summary>
    [SerializeField] private float velocityMultiplier = 1.1f;
    /// <summary>
    /// Reference to the Rigidbody2D component of the ball
    /// </summary>
    private Rigidbody2D ballTb;

    /// <summary>
    /// Called at the start of the game.
    /// </summary>
    void Start()
    {
        ballTb = GetComponent<Rigidbody2D>();
        Launch();
    }

    /// <summary>
    /// Launches the ball by giving it an initial random velocity.
    /// </summary>
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballTb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;

    }

    /// <summary>
    /// Called when the ball collides with an object.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            ballTb.velocity *= velocityMultiplier;
        }
    }

    /// <summary>
    /// Called when the ball triggers a collider.
    /// </summary>
    /// <param name="collision">The collider data.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            GManager.Instance.Paddle2Scored();
            GManager.Instance.Restart();
            Launch();
        }
        else
        {
            GManager.Instance.Paddle1Scored();
            GManager.Instance.Restart();
            Launch();
        }
    }
}
