using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of the main image in the memory game.
/// </summary>
public class MainImageScript : MonoBehaviour
{
    /// <summary>
    /// Reference to the unknown image object.
    /// </summary>
    [SerializeField] private GameObject image_unknown;
    /// <summary>
    /// Reference to the game controller.
    /// </summary>
    [SerializeField] private GameControllerScript gameController;

    /// <summary>
    /// Called when the mouse button is pressed down on the object.
    /// Checks if the unknown image is active and the game allows opening a card,
    /// then hides the unknown image and notifies the game controller.
    /// </summary>
    public void OnMouseDown()
    {
        if (image_unknown.activeSelf && gameController.canOpen) 
        { 
            image_unknown.SetActive(false);
            gameController.imageOpnened(this);
        }
    }

    /// <summary>
    /// The ID of the sprite.
    /// </summary>
    private int _spriteId;

    /// <summary>
    /// Gets the ID of the sprite.
    /// </summary>
    public int spriteId
    {
        get { return _spriteId; }
    }

    /// <summary>
    /// Length property of unknown purpose.
    /// </summary>
    public int Length { get; internal set; }

    /// <summary>
    /// Changes the sprite of the main image.
    /// </summary>
    /// <param name="id">The ID of the sprite.</param>
    /// <param name="image">The new sprite image.</param>
    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image; //Gets the sprite renderer component to change the sprite.
    }

    /// <summary>
    /// Hides the unknown image, closing the main image.
    /// </summary>
    public void Close()
    {
        image_unknown.SetActive(true); // Hide image.
    }
}
