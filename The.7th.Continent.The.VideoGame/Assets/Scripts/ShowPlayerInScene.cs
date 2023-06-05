using UnityEngine;

/// <summary>
/// Class that makes the character of your choice appear on the scene
/// </summary>
public class ShowPlayerInScene : MonoBehaviour
{
    /// <summary>
    /// Represents a GameObject
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Function that makes the character of your choice appear on the scene
    /// </summary>
    void Start()
    {
        GameObject child = GameObject.Instantiate(player);
        child.transform.parent = this.gameObject.transform; //or whatever gameobj will be its parent
    }
    
}
