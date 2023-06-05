using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that will lead to a victory screen after getting past the previous scenarios.
/// </summary>
public class NextLevel : MonoBehaviour
{

    /// <summary>
    /// Function that will check if the character comes into contact with the statue. 
    /// And if so, it will change the scene to a victory scene.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SurviveTheLavaEnemy");
        }
        
        
    }
}
