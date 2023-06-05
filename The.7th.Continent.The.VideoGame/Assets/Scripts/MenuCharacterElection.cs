using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that represents the menu where you choose the playable character.
/// </summary>
public class MenuCharacterElection : MonoBehaviour
{
    /// <summary>
    /// Reference index for characters
    /// </summary>
    private int index;
    /// <summary>
    /// Reference to the image
    /// </summary>
    [SerializeField] private Image image;
    /// <summary>
    /// Reference to text
    /// </summary>
    [SerializeField] private TextMeshProUGUI characterName;
    /// <summary>
    /// Reference for the GameManager
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// At Start, we make the GameManager equal to the instance we created in the script.
    /// </summary>
    private void Start()
    {
        gameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("IndexPlayer");

        ChangeValuesScreen();

        if(index > gameManager.characters.Count - 1)
        {
            index = 0;
        }
    }
    /// <summary>
    /// Method to change the values on the screen
    /// </summary>
    private void ChangeValuesScreen()
    {
        PlayerPrefs.SetInt("IndexPlayer", index);
        image.sprite = gameManager.characters[index].imagen;
        characterName.text = gameManager.characters[index].characterName;
    }

    /// <summary>
    /// Method to switch to the next character using the button
    /// </summary>
    public void NextCharacter()
    {
        if(index == gameManager.characters.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        ChangeValuesScreen();
    }
    /// <summary>
    /// Method to switch to the next character using the button
    /// </summary>
    public void BeforeCharacter()
    {
        if (index == 0)
        {
            index = gameManager.characters.Count - 1;
        }
        else
        {
            index -= 1;
        }

        ChangeValuesScreen();
    }

    /// <summary>
    /// Function that switches to scene 1 of the game and resets the gems number to zero.
    /// </summary>
    public void StartGame()
    {
        PlayerPrefs.SetInt("gems", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
