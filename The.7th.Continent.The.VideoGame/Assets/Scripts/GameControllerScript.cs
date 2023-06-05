using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    /// <summary>
    /// The number of columns in the game grid
    /// </summary>
    public const int columns = 4;
    /// <summary>
    /// The number of rows in the game grid
    /// </summary>
    public const int rows = 2;
    /// <summary>
    /// The horizontal spacing between cards
    /// </summary>
    public const float Xspace = 4f;
    /// <summary>
    /// The vertical spacing between cards
    /// </summary>
    public const float Yspace = -3f;
    /// <summary>
    /// The template object for the game images
    /// </summary>
    [SerializeField] private MainImageScript startObject;
    /// <summary>
    /// An array of card images
    /// </summary>
    [SerializeField] private Sprite[] images;
    /// <summary>
    /// The image object to display when the player wins
    /// </summary>
    public GameObject winImage;

    /// <summary>
    /// Randomizes the order of locations array using Fisher-Yates algorithm.
    /// </summary>
    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for(int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    /// <summary>
    /// Instantiate game images in a grid layout
    /// </summary>
    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3};
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MainImageScript gameImage
                    ;
                if(i == 0 & j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    /// <summary>
    /// The first card opened by the player
    /// </summary>
    private MainImageScript firstOpen;
    /// <summary>
    /// The second card opened by the player
    /// </summary>
    private MainImageScript secondOpen;
    /// <summary>
    /// The player's current score
    /// </summary>
    private int score = 0;
    /// <summary>
    /// The number of attempts made by the player
    /// </summary>
    private int attempts = 0;

    /// <summary>
    /// The text object to display the score
    /// </summary>
    [SerializeField] private TextMesh scoreText;
    /// <summary>
    /// The text object to display the number of attempts
    /// </summary>
    [SerializeField] private TextMesh attempsText;


    /// <summary>
    /// Gets a value indicating whether the second card can be opened.
    /// </summary>
    public bool canOpen
    {
        get { return secondOpen ==  null; }
    }

    /// <summary>
    /// Called when an image is opened (clicked) by the player.
    /// </summary>
    /// <param name="startObject"></param>
    public void imageOpnened(MainImageScript startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    /// <summary>
    /// Checks if the two opened cards match and updates the game state accordingly.
    /// </summary>
    private IEnumerator CheckGuessed()
    {
        if(firstOpen.spriteId == secondOpen.spriteId) // Compare the two objects 
        {
            score++; // Add score 
            scoreText.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f); //Sart timer
            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attempsText.text = "Attemps: " + attempts;

        firstOpen = null;
        secondOpen = null;

        if(score == 4)
        {
            winImage.SetActive(true);
        }

    }

    /// <summary>
    /// Restarts the game by reloading the current scene.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("MiniGameCards");
    }

    /// <summary>
    /// Returns to the main game menu by loading the Level1 scene.
    /// </summary>
    public void ReturnToGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
