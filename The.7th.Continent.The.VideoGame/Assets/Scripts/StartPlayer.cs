using UnityEngine;

/// <summary>
/// Class that instantiates the character in the scene
/// </summary>
public class StartPlayer : MonoBehaviour
{
    /// <summary>
    /// Represents a GameObject 
    /// </summary>
    private GameObject player;
    /// <summary>
    /// Represents a GameObject 
    /// </summary>
    public GameObject target;


    /// <summary>
    /// In this function the index of the character is taken from the prefabs folder, 
    /// and then the character is instantiated by taking it from the list created in the GameManager
    /// </summary>
    private void Start()
    {
        Time.timeScale = 1;

        int indexPlayer = PlayerPrefs.GetInt("IndexPlayer");
        
        player = Instantiate(GameManager.Instance.characters[indexPlayer].character, transform.position, Quaternion.identity);
        
        target.transform.parent = player.transform;

    }
}

