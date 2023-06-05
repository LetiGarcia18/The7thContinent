using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Triggers the display of a note when the player enters the trigger area.
/// </summary>
public class NoteTrigger : MonoBehaviour
{
    /// <summary>
    /// Reference to the NoteManager script responsible for managing notes.
    /// </summary>
    public NoteManager noteManager;

    /// <summary>
    /// Called when another collider enters the trigger collider.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            noteManager.ShowNote();
            gameObject.SetActive(false);
        }
    }
}
