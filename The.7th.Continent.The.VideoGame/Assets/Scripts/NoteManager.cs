using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the display and hiding of a note in the game.
/// </summary>
public class NoteManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the note image object.
    /// </summary>
    public GameObject noteImage;
    /// <summary>
    /// Flag to indicate if the game is paused.
    /// </summary>
    private bool isPaused = false;

    /// <summary>
    /// Updates the game state based on the pause status.
    /// </summary>
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    /// <summary>
    /// Shows the note and pauses the game.
    /// </summary>
    public void ShowNote()
    {
        isPaused = true;
        noteImage.SetActive(true);
    }

    /// <summary>
    /// Hides the note and resumes the game.
    /// </summary>
    public void HideNote()
    {
        isPaused = false;
        noteImage.SetActive(false);
    }
}
