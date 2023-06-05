using UnityEngine;

/// <summary>
/// Class that makes an animation appear every time the character picks up an item.
/// </summary>
public class ItemCollected : MonoBehaviour
{
    /// <summary>
    /// If the character comes into contact with the item, the item will disappear, and an animation will come out.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            GetComponent<SpriteRenderer>().enabled = false; 
            gameObject.transform.GetChild(0).gameObject.SetActive(true); 
            Destroy(gameObject, 0.2f);
        }
    }
}
