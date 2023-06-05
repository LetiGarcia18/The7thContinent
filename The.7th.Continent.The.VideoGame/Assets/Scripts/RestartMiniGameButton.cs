using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the behavior of a restart button in a mini-game.
/// </summary>
public class RestartMiniGameButton : MonoBehaviour
{
    /// <summary>
    /// Reference to the GameControllerScript for communication
    /// </summary>
    [SerializeField] private GameControllerScript gameController;
    /// <summary>
    /// Name of the function to call on the GameControllerScript when the button is clicked
    /// </summary>
    [SerializeField] private string functionOnClick;

    /// <summary>
    /// Called when the mouse is over the button.
    /// Changes the color of the button sprite to cyan.
    /// </summary>
    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.cyan;
        }
    }

    /// <summary>
    /// Called when the mouse button is pressed down on the button.
    /// Sets the scale of the button to make it appear pressed.
    /// </summary>
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
    }

    /// <summary>
    /// Called when the mouse button is released after being pressed down on the button.
    /// Resets the scale of the button and sends a message to the GameControllerScript.
    /// </summary>
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        if(gameController != null)
        {
            gameController.SendMessage(functionOnClick);
        }
    }

    /// <summary>
    /// Called when the mouse exits the area of the button.
    /// Resets the color of the button sprite to white.
    /// </summary>
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.white;
        } 
    }
}
