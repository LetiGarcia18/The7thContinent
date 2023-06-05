using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A script that triggers a scene transition to a mini-game when the player enters a trigger zone.
/// </summary>
public class GoToMiniGame : MonoBehaviour
{
    /// <summary>
    /// The name of the specified scene
    /// </summary>
    public string sceneName;

    /// <summary>
    /// Called when a 2D collider enters the trigger zone.
    /// Checks if the collider belongs to the player and triggers a scene transition.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
