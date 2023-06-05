using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that will check if the character has reclosed the necessary submarine pieces to be able to go to the next scenario.
/// </summary>
public class NextLevelPiecesSubmarine : MonoBehaviour
{
    /// <summary>
    /// Text representing the submarine parts counter.
    /// </summary>
    public TextMeshProUGUI counterNumber;
    /// <summary>
    /// Text that tells us that we must find the submarine parts.
    /// </summary>
    public TextMeshProUGUI findSubmarinePieceText;

    public string sceneName;

    public int submarinePieces;

    /// <summary>
    /// Function that checks if the necessary submarine parts have been collected. 
    /// If so, the character will be able to move on to the next scene. 
    /// If not, a text appears on the screen indicating that the submarine pieces must be found in order to continue.
    /// </summary>
    /// <param name="other">Represents a GameObject</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && counterNumber.text.Equals(submarinePieces.ToString()))
        {
            
            SceneManager.LoadScene(sceneName);
        }
        else 
        {
            findSubmarinePieceText.gameObject.SetActive(true);
        }
        
    }
}
