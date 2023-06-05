using UnityEngine;

/// <summary>
/// Function that represents that, when the character takes a certain item, his speed increases for a while.
/// Inherits from the ItemCollected class.
/// </summary>
public class SpeedBoostCollected : ItemCollected
{
    /// <summary>
    /// Variable that represents the time of the speed
    /// </summary>
    public float speedTime;

    /// <summary>
    /// Function that makes that when the character picks up the item, his speed increases for a certain time, 
    /// and also, the item disappears
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var playerMovement = other.GetComponentInParent<PlayerMovement>();
            playerMovement.SetAccelerationForSeconds(speedTime);
        }

        base.OnTriggerEnter2D(other);
    }
}
