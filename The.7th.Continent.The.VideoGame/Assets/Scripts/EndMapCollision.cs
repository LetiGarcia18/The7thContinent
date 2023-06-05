using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This script handles the collision with the end map trigger and loads a specified scene.
/// </summary>
public class EndMapCollision : MonoBehaviour
{
    /// <summary>
    /// Name of the scene to load
    /// </summary>
    public String sceneName;

    /// <summary>
    /// Detects collision with the player and loads the specified scene.
    /// </summary>
    /// <param name="other">The collider of the other object.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);

        }
    }
   
}
