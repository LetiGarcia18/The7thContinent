using UnityEngine;

/// <summary>
/// Function that show up an image of the scene map
/// </summary>
public class ShowLevelMap : MonoBehaviour
{
    /// <summary>
    /// Variable representing the map image
    /// </summary>
    public GameObject mapImage;

    /// <summary>
    /// Function that, if the character takes the map item, the map image appears
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            mapImage.SetActive(true);
        }

    }


}
